using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class UserAddressRepository : RepositoryBase<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<PagedList<UserAddress>> GetAddressesForUserAsync(
            string userId,
            UserAddressRequestParameters parameters,
            bool trackChanges)
        {
            var addresses = await FindByCondition(a => a.UserId == userId, trackChanges)
                .FilterByDefaultStatus(parameters.IsDefault)
                .Search(parameters.SearchTerm)
                .OrderBy(a => a.Label)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(a => a.UserId == userId, trackChanges)
                .FilterByDefaultStatus(parameters.IsDefault)
                .Search(parameters.SearchTerm)
                .CountAsync();

            return new PagedList<UserAddress>(addresses, count, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<UserAddress> GetAddressAsync(Guid addressId, bool trackChanges) =>
            await FindByCondition(a => a.AddressId == addressId, trackChanges)
                .SingleOrDefaultAsync();

        public async Task<UserAddress> GetDefaultAddressAsync(string userId, bool trackChanges) =>
            await FindByCondition(a => a.UserId == userId && a.IsDefault, trackChanges)
                .FirstOrDefaultAsync();

        public async Task<bool> AddressBelongsToUserAsync(Guid addressId, string userId, bool trackChanges) =>
            await FindByCondition(a => a.AddressId == addressId && a.UserId == userId, trackChanges)
                .AnyAsync();
        public async Task<bool> UserHasAddressesAsync(string userId) =>
           await FindByCondition(a => a.UserId == userId, false)
                .AnyAsync();

        public async Task<UserAddress> FindNextAvailableAddress(string userId, Guid addressIdToExclude) =>
        
             await FindByCondition(a => a.UserId == userId && a.AddressId != addressIdToExclude, false)
                .OrderBy(a => a.Location.CreatedDate)
                .FirstOrDefaultAsync();
        
        public void CreateAddress(string userId, UserAddress address)
        {
            address.UserId = userId;
            Create(address);
        }

        public void DeleteAddress(UserAddress address) => Delete(address);

        public void SetAsDefault(UserAddress address)
        {
            address.IsDefault = true;
            Update(address);
        }

        public void UpdateAddress(UserAddress address) => Update(address);
    }
}