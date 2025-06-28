using Entities.Models;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userName, bool trackChanges);
        Task<PagedList<User>> GetUsersAsync(UserParameters userParameters, bool trackChanges);
        void DeleteUser(User user);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
    }
}
