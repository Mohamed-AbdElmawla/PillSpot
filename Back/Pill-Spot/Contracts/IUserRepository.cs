using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userName, bool trackChanges);
        Task<PagedList<User>> GetUsersAsync(UserParameters userParameters, bool trackChanges);
        void DeleteUser(User user);

    }
}
