using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICartItemRepository
    {
        Task<PagedList<CartItem>> GetCartItemsByCartIdAsync(Guid cartId, CartItemRequestParameters parameters, bool trackChanges);
        Task<IEnumerable<CartItem>> GetItemsByPharmacyAsync(Guid cartId, Guid pharmacyId, bool trackChanges);
        Task<IEnumerable<CartItem>> GetCartItemsWithDetailsAsync(Guid cartId, bool trackChanges);
        Task<CartItem> GetCartItemByIdsAsync(Guid cartId, Guid productId, Guid pharmacyId, bool trackChanges);
        Task<IEnumerable<CartItem>> GetPendingApprovalItemsAsync(Guid cartId, bool trackChanges);
        Task<int> GetItemCountByCartAsync(Guid cartId, bool trackChanges);
        Task UpdateItemApprovalsAsync(
            Guid cartId,
            Dictionary<Guid, (CartItemApprovalStatus? Status, string? Reason, RejectionType? Type, string? RespondedByUserId)> approvals,
            bool trackChanges);
        Task DeleteItemsByCartAsync(Guid cartId, bool trackChanges);
        void CreateItem(CartItem item);
        void UpdateItem(CartItem item);
        void DeleteItem(CartItem item);
    }
}