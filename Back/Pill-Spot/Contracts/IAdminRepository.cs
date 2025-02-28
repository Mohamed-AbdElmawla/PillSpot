using Entities.Models;

namespace Contracts
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(string userId);
        Task UpdateUserAsync(User user);
    }
}
