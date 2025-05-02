using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserAddressRepository
    {
        Task<PagedList<UserAddress>> GetAddressesForUserAsync(string userId, UserAddressRequestParameters parameters, bool trackChanges);
        Task<UserAddress> GetAddressAsync(Guid addressId, bool trackChanges);
        Task<UserAddress> GetDefaultAddressAsync(string userId, bool trackChanges);
        Task<bool> AddressBelongsToUserAsync(Guid addressId, string userId, bool trackChanges);
        Task<bool> UserHasAddressesAsync(string userId);
        Task<UserAddress> FindNextAvailableAddress(string userId, Guid addressIdToExclude);
        void CreateAddress(string userId, UserAddress address);
        void DeleteAddress(UserAddress address);
        void SetAsDefault(UserAddress address);
        void UpdateAddress(UserAddress address);
    }
}