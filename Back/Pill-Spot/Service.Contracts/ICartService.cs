using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICartService
    {
        Task<(IEnumerable<CartDto> carts, MetaData metaData)> GetAllCartsAsync(CartRequestParameters cartParameters);
        Task<CartDto> GetCartAsync(Guid cartId);
        Task<CartDto> GetCartWithItemsAsync(Guid cartId);
        Task<CartDto> GetUserCartAsync(string userId);
        Task<CartDto> GetGuestCartAsync(Guid guestCartId);
        Task<CartDto> CreateCartAsync(CartForCreationDto cart);
        Task<(IEnumerable<CartDto> carts, string ids)> CreateCartCollectionAsync(IEnumerable<CartForCreationDto> cartCollection);
        Task UpdateCartAsync(Guid cartId, CartForUpdateDto cart);
        Task DeleteCartAsync(Guid cartId);
        Task LockCartAsync(Guid cartId);
        Task UnlockCartAsync(Guid cartId);
        Task CleanupExpiredGuestCartsAsync(DateTime cutoffDate);
        Task<int> GetCartItemCountAsync(Guid cartId);
        Task<Dictionary<Guid, decimal>> GetCartPharmacyTotalsAsync(Guid cartId);
    }
}