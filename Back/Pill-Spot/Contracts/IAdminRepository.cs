using Entities.Models;

namespace Contracts
{
    public interface IAdminRepository
    {
        Task<User?> GetUserByIdAsync(string userId, bool trackChanges);
    }
}
