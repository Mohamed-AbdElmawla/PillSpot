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
    internal sealed class CartItemService : ICartItemService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;

        public CartItemService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
        }

        public async Task<(IEnumerable<CartItemDto> items, MetaData metaData)> GetCartItemsByCartIdAsync(Guid cartId, CartItemRequestParameters parameters)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            var items = await _repository.CartItemRepository.GetCartItemsByCartIdAsync(cartId, parameters, false);
            var itemsDto = _mapper.Map<IEnumerable<CartItemDto>>(items);
            return (items: itemsDto, metaData: items.MetaData);
        }

        public async Task<IEnumerable<CartItemDto>> GetItemsByPharmacyAsync(Guid cartId, Guid pharmacyId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            var items = await _repository.CartItemRepository.GetItemsByPharmacyAsync(cartId, pharmacyId, false);
            return _mapper.Map<IEnumerable<CartItemDto>>(items);
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsWithDetailsAsync(Guid cartId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            var items = await _repository.CartItemRepository.GetCartItemsWithDetailsAsync(cartId, false);
            return _mapper.Map<IEnumerable<CartItemDto>>(items);
        }

        public async Task<CartItemDto> GetCartItemByIdsAsync(Guid cartId, Guid productId, Guid pharmacyId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            var item = await _repository.CartItemRepository.GetCartItemByIdsAsync(cartId, productId, pharmacyId, false);
            if (item == null || item.IsDeleted)
                throw new CartItemNotFoundException(cartId, productId, pharmacyId);

            return _mapper.Map<CartItemDto>(item);
        }

        public async Task<IEnumerable<CartItemDto>> GetPendingApprovalItemsAsync(Guid cartId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartDeactivatedException(cartId);

            var items = await _repository.CartItemRepository.GetPendingApprovalItemsAsync(cartId, false);
            return _mapper.Map<IEnumerable<CartItemDto>>(items);
        }

        public async Task<CartItemDto> CreateCartItemAsync(CartItemForCreationDto itemDto)
        {
            if (itemDto.Quantity < 1)
                throw new InvalidQuantityException(itemDto.Quantity);

            var cart = await _repository.CartRepository.GetCartAsync(itemDto.CartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(itemDto.CartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartInactiveException(itemDto.CartId);

            if (cart.ExpiresAt <= DateTime.UtcNow)
                throw new CartDeactivatedException(itemDto.CartId);

            if (await _repository.CartRepository.IsCartLockedAsync(itemDto.CartId, false))
                throw new CartLockedException(itemDto.CartId);

            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(itemDto.ProductId, itemDto.PharmacyId, false);
            if (pharmacyProduct == null || pharmacyProduct.IsDeleted || !pharmacyProduct.IsAvailable)
                throw new PharmacyProductNotFoundException(itemDto.ProductId, itemDto.PharmacyId);

            if (pharmacyProduct.Quantity < itemDto.Quantity)
                throw new InsufficientStockException(itemDto.ProductId, itemDto.PharmacyId, itemDto.Quantity, pharmacyProduct.Quantity);

            bool requiresPrescription = pharmacyProduct.Product is Medicine medicine && medicine.IsPrescriptionRequired;
            if (requiresPrescription && itemDto.PrescriptionImage == null)
                throw new PrescriptionRequiredException(itemDto.ProductId);

            var itemEntity = _mapper.Map<CartItem>(itemDto);
            itemEntity.CartItemId = Guid.NewGuid();
            itemEntity.PriceAtAddition = (decimal)pharmacyProduct.Product.Price;
            itemEntity.AddedAt = DateTime.UtcNow;
            itemEntity.PharmacyApproved = requiresPrescription ? CartItemApprovalStatus.Pending : CartItemApprovalStatus.Approved;

            if (itemDto.PrescriptionImage != null)
            {
                string imagePath = await _fileService.SaveFileAsync(itemDto.PrescriptionImage, "Prescriptions");
                itemEntity.PrescriptionImageUrl = imagePath;
                itemEntity.PrescriptionUploadedAt = DateTime.UtcNow;
            }

            await _repository.BeginTransactionAsync();
            try
            {
                _repository.CartItemRepository.CreateItem(itemEntity);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }

            var itemToReturn = _mapper.Map<CartItemDto>(itemEntity);
            return itemToReturn;
        }

        public async Task UpdateCartItemAsync(Guid cartId, Guid productId, Guid pharmacyId, CartItemForUpdateDto itemDto)
        {
            if (itemDto.Quantity < 1)
                throw new InvalidQuantityException(itemDto.Quantity);

            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartInactiveException(cartId);

            if (cart.ExpiresAt <= DateTime.UtcNow)
                throw new CartDeactivatedException(cartId);

            if (await _repository.CartRepository.IsCartLockedAsync(cartId, false))
                throw new CartLockedException(cartId);

            var itemEntity = await _repository.CartItemRepository.GetCartItemByIdsAsync(cartId, productId, pharmacyId, true);
            if (itemEntity == null || itemEntity.IsDeleted)
                throw new CartItemNotFoundException(cartId, productId, pharmacyId);

            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(productId, pharmacyId, false);
            if (pharmacyProduct == null || pharmacyProduct.IsDeleted || !pharmacyProduct.IsAvailable)
                throw new PharmacyProductNotFoundException(productId, pharmacyId);

            if (pharmacyProduct.Quantity < itemDto.Quantity)
                throw new InsufficientStockException(productId, pharmacyId, itemDto.Quantity, pharmacyProduct.Quantity);

            bool requiresPrescription = pharmacyProduct.Product is Medicine medicine && medicine.IsPrescriptionRequired;
            if (requiresPrescription && string.IsNullOrEmpty(itemEntity.PrescriptionImageUrl) && itemDto.PrescriptionImage == null)
                throw new PrescriptionRequiredException(productId);

            _mapper.Map(itemDto, itemEntity);

            if (itemDto.PrescriptionImage != null)
            {
                if (!string.IsNullOrEmpty(itemEntity.PrescriptionImageUrl))
                {
                    await _fileService.DeleteFileAsync(itemEntity.PrescriptionImageUrl);
                }
                string imagePath = await _fileService.SaveFileAsync(itemDto.PrescriptionImage, "Prescriptions");
                itemEntity.PrescriptionImageUrl = imagePath;
                itemEntity.PrescriptionUploadedAt = DateTime.UtcNow;
                itemEntity.PharmacyApproved = CartItemApprovalStatus.Pending;
            }

            await _repository.BeginTransactionAsync();
            try
            {
                _repository.CartItemRepository.UpdateItem(itemEntity);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task DeleteCartItemAsync(Guid cartId, Guid productId, Guid pharmacyId)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartInactiveException(cartId);

            if (cart.ExpiresAt <= DateTime.UtcNow)
                throw new CartDeactivatedException(cartId);

            if (await _repository.CartRepository.IsCartLockedAsync(cartId, false))
                throw new CartLockedException(cartId);

            var itemEntity = await _repository.CartItemRepository.GetCartItemByIdsAsync(cartId, productId, pharmacyId, true);
            if (itemEntity == null || itemEntity.IsDeleted)
                throw new CartItemNotFoundException(cartId, productId, pharmacyId);

            await _repository.BeginTransactionAsync();
            try
            {
                if (!string.IsNullOrEmpty(itemEntity.PrescriptionImageUrl))
                {
                    await _fileService.DeleteFileAsync(itemEntity.PrescriptionImageUrl);
                }
                _repository.CartItemRepository.DeleteItem(itemEntity);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task UpdateItemApprovalsAsync(Guid cartId, IEnumerable<CartItemApprovalDto> approvals)
        {
            var cart = await _repository.CartRepository.GetCartAsync(cartId, false);
            if (cart == null || cart.IsDeleted)
                throw new CartNotFoundException(cartId);

            if (cart.CartType == "User" && !await IsCartActiveAsync(cart))
                throw new CartInactiveException(cartId);

            if (cart.ExpiresAt <= DateTime.UtcNow)
                throw new CartDeactivatedException(cartId);

            var approvalDict = approvals.ToDictionary(
                a => a.CartItemId,
                a => (a.Status, a.Reason, a.Type, a.RespondedByUserId)
            );

            foreach (var approval in approvals)
            {
                if (approval.RespondedByUserId != null)
                {
                    var user = await _userManager.FindByIdAsync(approval.RespondedByUserId);
                    if (user == null)
                        throw new UserNotFoundException(approval.RespondedByUserId);
                }
            }

            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.CartItemRepository.UpdateItemApprovalsAsync(cartId, approvalDict, true);
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
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