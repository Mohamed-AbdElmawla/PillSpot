using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CartService : ICartService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CartService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<(IEnumerable<CartDto> carts, MetaData metaData)> GetAllCartsAsync(CartRequestParameters cartParameters)
        {
            var carts = await _repository.CartRepository.GetAllCartsAsync(cartParameters, false);
            var cartsDto = _mapper.Map<IEnumerable<CartDto>>(carts);
            return (carts: cartsDto, metaData: carts.MetaData);
        }

        public async Task<CartDto> GetCartAsync(Guid cartId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            var cartDto = _mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task<CartDto> GetCartWithItemsAsync(Guid cartId)
        {
            var cart = await _repository.CartRepository.GetCartWithItemsAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            var cartDto = _mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task<CartDto> GetUserCartAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            var cart = await _repository.CartRepository.GetUserCartAsync(userId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(userId);

            if (!await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cart.CartId);

            var cartDto = _mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task<CartDto> GetGuestCartAsync(Guid guestCartId)
        {
            var cart = await _repository.CartRepository.GetGuestCartAsync(guestCartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(guestCartId);

            if (cart.ExpiresAt <= DateTime.UtcNow)
                throw new CartDeactivatedException(guestCartId);

            var cartDto = _mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task<CartDto> CreateCartAsync(CartForCreationDto cartDto)
        {
            if (cartDto.CartType != "User" && cartDto.CartType != "Guest")
                throw new InvalidCartTypeException(cartDto.CartType);

            if (cartDto.CartType == "User")
            {
                if (string.IsNullOrEmpty(cartDto.UserId))
                    throw new Exception("UserId is required for User cart type.");

                var user = await _userManager.FindByIdAsync(cartDto.UserId);
                if (user == null)
                    throw new UserNotFoundException(cartDto.UserId);

                var existingCart = await _repository.CartRepository.GetUserCartAsync(cartDto.UserId, false);
                if (existingCart != null && !existingCart.IsDeleted)
                    throw new CartAlreadyExistsException(cartDto.UserId);
            }

            if (cartDto.DeliveryAddressId.HasValue)
            {
                var address = await _repository.UserAddressRepository.GetAddressAsync(cartDto.DeliveryAddressId.Value, false);
                if (address == null)
                    throw new InvalidDeliveryAddressException(cartDto.DeliveryAddressId.Value);
            }

            var cartEntity = _mapper.Map<Cart>(cartDto);
            cartEntity.CartId = Guid.NewGuid();
            cartEntity.LastAccessed = DateTime.UtcNow;
            cartEntity.ExpiresAt = cartDto.CartType == "Guest" ? DateTime.UtcNow.AddDays(7) : null;

            await _repository.BeginTransactionAsync();
            try
            {
                _repository.CartRepository.CreateCart(cartEntity);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }

            var cartToReturn = _mapper.Map<CartDto>(cartEntity);
            return cartToReturn;
        }

        public async Task<(IEnumerable<CartDto> carts, string ids)> CreateCartCollectionAsync(IEnumerable<CartForCreationDto> cartCollection)
        {
            if (cartCollection == null)
                throw new CartCollectionBadRequest();

            var cartEntities = _mapper.Map<IEnumerable<Cart>>(cartCollection);
            var createdCarts = new List<Cart>();

            await _repository.BeginTransactionAsync();
            try
            {
                foreach (var cart in cartEntities)
                {
                    if (cart.CartType != "User" && cart.CartType != "Guest")
                        throw new InvalidCartTypeException(cart.CartType);

                    if (cart.CartType == "User")
                    {
                        if (string.IsNullOrEmpty(cart.UserId))
                            throw new Exception("UserId is required for User cart type.");

                        var user = await _userManager.FindByIdAsync(cart.UserId);
                        if (user == null)
                            throw new UserNotFoundException(cart.UserId);

                        var existingCart = await _repository.CartRepository.GetUserCartAsync(cart.UserId, false);
                        if (existingCart != null && !existingCart.IsDeleted)
                            throw new CartAlreadyExistsException(cart.UserId);
                    }

                    if (cart.DeliveryAddressId.HasValue)
                    {
                        var address = await _repository.UserAddressRepository.GetAddressAsync(cart.DeliveryAddressId.Value, false);
                        if (address == null)
                            throw new InvalidDeliveryAddressException(cart.DeliveryAddressId.Value);
                    }

                    cart.CartId = Guid.NewGuid();
                    cart.LastAccessed = DateTime.UtcNow;
                    cart.ExpiresAt = cart.CartType == "Guest" ? DateTime.UtcNow.AddDays(7) : null;

                    _repository.CartRepository.CreateCart(cart);
                    createdCarts.Add(cart);
                }

                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }

            var cartCollectionToReturn = _mapper.Map<IEnumerable<CartDto>>(createdCarts);
            var ids = string.Join(",", cartCollectionToReturn.Select(c => c.CartId));

            return (carts: cartCollectionToReturn, ids: ids);
        }

        public async Task UpdateCartAsync(Guid cartId, CartForUpdateDto cartDto)
        {
            var cartEntity = await _repository.CartRepository.GetCartAsync(cartId, true);
            if (cartEntity == null || cartEntity.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cartEntity.CartType == "User" && !await IsCartActiveAsync(cartEntity))
                throw new CartInactiveException(cartId);

            if (cartEntity.ExpiresAt <= DateTime.UtcNow)
                throw new CartDeactivatedException(cartId);

            if (await _repository.CartRepository.IsCartLockedAsync(cartId, false))
                throw new CartLockedException(cartId);

            if (cartDto.DeliveryAddressId.HasValue)
            {
                var address = await _repository.UserAddressRepository.GetAddressAsync(cartDto.DeliveryAddressId.Value, false);
                if (address == null)
                    throw new InvalidDeliveryAddressException(cartDto.DeliveryAddressId.Value);
            }

            _mapper.Map(cartDto, cartEntity);
            cartEntity.LastAccessed = DateTime.UtcNow;

            await _repository.BeginTransactionAsync();
            try
            {
                _repository.CartRepository.UpdateCart(cartEntity);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task DeleteCartAsync(Guid cartId)
        {
            var cartEntity = await _repository.CartRepository.GetCartAsync(cartId, true);
            if (cartEntity == null || cartEntity.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (await _repository.CartRepository.IsCartLockedAsync(cartId, false))
                throw new CartLockedException(cartId);

            await _repository.BeginTransactionAsync();
            try
            {
                _repository.CartRepository.DeleteCart(cartEntity);
                await _repository.CartItemRepository.DeleteItemsByCartAsync(cartId, true);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task LockCartAsync(Guid cartId)
        {
            var cartEntity = await _repository.CartRepository.GetCartAsync(cartId, true);
            if (cartEntity == null || cartEntity.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cartEntity.CartType == "User" && !await IsCartActiveAsync(cartEntity))
                throw new CartInactiveException(cartId);

            if (cartEntity.ExpiresAt <= DateTime.UtcNow)
                throw new CartDeactivatedException(cartId);

            if (await _repository.CartRepository.IsCartLockedAsync(cartId, false))
                throw new CartLockedException(cartId);

            cartEntity.IsLocked = true;
            cartEntity.LockedAt = DateTime.UtcNow;
            cartEntity.LastAccessed = DateTime.UtcNow;

            await _repository.BeginTransactionAsync();
            try
            {
                _repository.CartRepository.UpdateCart(cartEntity);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task UnlockCartAsync(Guid cartId)
        {
            var cartEntity = await _repository.CartRepository.GetCartAsync(cartId, true);
            if (cartEntity == null || cartEntity.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (!await _repository.CartRepository.IsCartLockedAsync(cartId, false))
                throw new CartIsNotLockedBadRequestException(cartId);

            cartEntity.IsLocked = false;
            cartEntity.LockedAt = null;
            cartEntity.LastAccessed = DateTime.UtcNow;

            await _repository.BeginTransactionAsync();
            try
            {
                _repository.CartRepository.UpdateCart(cartEntity);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task CleanupExpiredGuestCartsAsync(DateTime cutoffDate)
        {
            var expiredCartIds = (await _repository.CartRepository.GetAllCartsAsync(
                new CartRequestParameters { PageSize = int.MaxValue }, false))
                .Where(c => c.CartType == "Guest" && c.ExpiresAt <= cutoffDate)
                .Select(c => c.CartId)
                .ToList();

            if (!expiredCartIds.Any())
                return;

            await _repository.BeginTransactionAsync();
            try
            {
                foreach (var cartId in expiredCartIds)
                {
                    await _repository.CartItemRepository.DeleteItemsByCartAsync(cartId, true);
                }
                await _repository.CartRepository.CleanupExpiredGuestCartsAsync(cutoffDate);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<int> GetCartItemCountAsync(Guid cartId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            return await _repository.CartRepository.GetCartItemCountAsync(cartId, false);
        }

        public async Task<Dictionary<Guid, decimal>> GetCartPharmacyTotalsAsync(Guid cartId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            return await _repository.CartRepository.GetCartPharmacyTotalsAsync(cartId, false);
        }

        private async Task<bool> IsCartActiveAsync(Cart cart)
        {
            if (cart.CartType != "User")
                return true;

            var user = await _userManager.FindByIdAsync(cart.UserId);
            return user != null;
        }
    }
}