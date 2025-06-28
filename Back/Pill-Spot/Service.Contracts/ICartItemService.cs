using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICartItemService
    {
        Task<(IEnumerable<CartItemDto> items, MetaData metaData)> GetCartItemsByCartIdAsync(Guid cartId, CartItemRequestParameters parameters);
        Task<IEnumerable<CartItemDto>> GetItemsByPharmacyAsync(Guid cartId, Guid pharmacyId);
        Task<IEnumerable<CartItemDto>> GetCartItemsWithDetailsAsync(Guid cartId);
        Task<CartItemDto> GetCartItemByIdsAsync(Guid cartId, Guid productId, Guid pharmacyId);
        Task<IEnumerable<CartItemDto>> GetPendingApprovalItemsAsync(Guid cartId);
        Task<CartItemDto> CreateCartItemAsync(CartItemForCreationDto item);
        Task UpdateCartItemAsync(Guid cartId, Guid productId, Guid pharmacyId, CartItemForUpdateDto item);
        Task DeleteCartItemAsync(Guid cartId, Guid productId, Guid pharmacyId);
        Task UpdateItemApprovalsAsync(Guid cartId, IEnumerable<CartItemApprovalDto> approvals);
    }
}