using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserAddressService
    {
        Task<(IEnumerable<UserAddressDto> addresses, MetaData metaData)> GetAddressesForUserAsync(
            string userId, UserAddressRequestParameters parameters, bool trackChanges);
        Task<UserAddressDto> GetAddressAsync(string userId, Guid addressId, bool trackChanges);
        Task<UserAddressDto> GetDefaultAddressAsync(string userId, bool trackChanges);
        Task<UserAddressDto> CreateAddressAsync(string userId, UserAddressForCreationDto addressDto);
        Task UpdateAddressAsync(string userId, Guid addressId, UserAddressForUpdateDto addressDto, bool trackChanges);
        Task DeleteAddressAsync(string userId, Guid addressId, bool trackChanges);
        Task SetDefaultAddressAsync(string userId, Guid addressId, bool trackChanges);
    }
}