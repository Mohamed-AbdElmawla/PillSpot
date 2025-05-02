using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICartRepository
    {
        Task<PagedList<Cart>> GetAllCartsAsync(CartRequestParameters cartRequestParameters, bool trackChanges);
        Task<Cart> GetCartAsync(Guid cartId, bool trackChanges);
        Task<Cart> GetCartWithItemsAsync(Guid cartId, bool trackChanges);
        Task<Cart> GetUserCartAsync(string userId, bool trackChanges);
        Task<Cart> GetGuestCartAsync(Guid guestCartId, bool trackChanges);
        Task<bool> CartExistsAsync(Guid cartId, bool trackChanges);
        Task UnlockExpiredCartsAsync(DateTime cutoffDate);
        Task CleanupExpiredGuestCartsAsync(DateTime cutoffDate);
        Task<int> GetCartItemCountAsync(Guid cartId, bool trackChanges);
        Task<bool> IsCartLockedAsync(Guid cartId, bool trackChanges);
        Task<Dictionary<Guid, decimal>> GetCartPharmacyTotalsAsync(Guid cartId, bool trackChanges);
        void CreateCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
    }
}