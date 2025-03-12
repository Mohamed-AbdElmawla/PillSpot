using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AdminRepository(RepositoryContext context) : RepositoryBase<User>(context), IAdminRepository
    {

        public async Task<User?> GetUserByIdAsync(string userId, bool trackChanges) => 
            await FindByCondition(a => a.Id.Equals(userId), trackChanges).SingleOrDefaultAsync();
    }
}