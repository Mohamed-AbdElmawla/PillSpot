using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly UserManager<User> _userManager;

        public AdminRepository(UserManager<User> userManager) => _userManager = userManager;

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userManager.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(string userId) => await _userManager.FindByIdAsync(userId);

        public async Task UpdateUserAsync(User user) => await _userManager.UpdateAsync(user);
    }
}