using Entities.Models;

namespace Contracts
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(string userId);
        void UpdateUserAsync(User user);
    }
}
