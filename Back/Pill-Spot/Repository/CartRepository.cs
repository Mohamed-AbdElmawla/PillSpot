using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Repository.Extentions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<Cart>> GetAllCartsAsync(CartRequestParameters cartParameters, bool trackChanges)
        {
            var carts = await FindAll(trackChanges)
                .ApplyCartFilters(cartParameters)
                .Skip((cartParameters.PageNumber - 1) * cartParameters.PageSize)
                .Take(cartParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges)
                .ApplyCartFilters(cartParameters)
                .CountAsync();

            return new PagedList<Cart>(carts, count, cartParameters.PageNumber, cartParameters.PageSize);
        }

        public async Task<Cart> GetCartAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(c => c.CartId.Equals(cartId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<Cart> GetCartWithItemsAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(c => c.CartId.Equals(cartId), trackChanges)
                .Include(c => c.Items)
                    .ThenInclude(i => i.PharmacyProduct)
                        .ThenInclude(pp => pp.Product)
                .Include(c => c.DeliveryAddress)
                    .ThenInclude(da => da!.Location)
                .SingleOrDefaultAsync();

        public async Task<Cart> GetUserCartAsync(string userId, bool trackChanges) =>
            await FindByCondition(c => c.UserId == userId && c.CartType == "User", trackChanges)
                .Include(c => c.Items)
                .Include(c => c.DeliveryAddress)
                    .ThenInclude(da => da!.Location)
                .SingleOrDefaultAsync();

        public async Task<Cart> GetGuestCartAsync(Guid guestCartId, bool trackChanges) =>
            await FindByCondition(c => c.CartId == guestCartId && c.CartType == "Guest", trackChanges)
                .Include(c => c.Items)
                .Include(c => c.DeliveryAddress)
                    .ThenInclude(da => da!.Location)
                .SingleOrDefaultAsync();

        public async Task<bool> CartExistsAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(c => c.CartId.Equals(cartId), trackChanges)
                .AnyAsync();

        public async Task CleanupExpiredGuestCartsAsync(DateTime cutoffDate) =>
            await FindByCondition(c => c.CartType == "Guest" && c.ExpiresAt <= cutoffDate, trackChanges: true)
                .ExecuteUpdateAsync(setters => setters.SetProperty(c => c.IsDeleted, true));

        public async Task<int> GetCartItemCountAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(c => c.CartId.Equals(cartId), trackChanges)
                .SelectMany(c => c.Items)
                .CountAsync();

        public async Task<bool> IsCartLockedAsync(Guid cartId, bool trackChanges)
        {
            var cart = await FindByCondition(c => c.CartId.Equals(cartId), trackChanges)
                .Select(c => new { c.IsLocked, c.LockedAt })
                .SingleOrDefaultAsync();
            return cart != null && cart.IsLocked && cart.LockedAt > DateTime.UtcNow.AddMinutes(-5);
        }

        public async Task<Dictionary<Guid, decimal>> GetCartPharmacyTotalsAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(c => c.CartId.Equals(cartId), trackChanges)
                .SelectMany(c => c.Items)
                .GroupBy(i => i.PharmacyId)
                .Select(g => new { PharmacyId = g.Key, Total = g.Sum(i => i.PriceAtAddition * i.Quantity) })
                .ToDictionaryAsync(x => x.PharmacyId, x => x.Total);
        public async Task UnlockExpiredCartsAsync(DateTime cutoffDate)=>
            await FindByCondition(c => c.IsLocked && c.LockedAt <= cutoffDate, trackChanges: true)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(c => c.IsLocked, false)
                    .SetProperty(c => c.LockedAt, (DateTime?)null));
        
        public void CreateCart(Cart cart) => Create(cart);
        public void UpdateCart(Cart cart) => Update(cart);
        public void DeleteCart(Cart cart) => cart.IsDeleted = true;

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await FindByCondition(c => c.UserId == userId && !c.IsDeleted, false)
                .Include(c => c.Items)
                .SingleOrDefaultAsync();
        }

        public void AddCartItem(CartItem cartItem)
        {
            var cart = FindByCondition(c => c.CartId == cartItem.CartId, true)
                .Include(c => c.Items)
                .SingleOrDefault();

            if (cart != null)
            {
                cart.Items.Add(cartItem);
                cart.LastAccessed = DateTime.UtcNow;
                Update(cart);
            }
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            var cart = FindByCondition(c => c.CartId == cartItem.CartId, true)
                .Include(c => c.Items)
                .SingleOrDefault();

            if (cart != null)
            {
                cart.Items.Remove(cartItem);
                cart.LastAccessed = DateTime.UtcNow;
                Update(cart);
            }
        }
    }
}