using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<User> GetUserAsync(string userName, bool trackChanges) 
            => await FindByCondition(u => userName.Equals(u.UserName), trackChanges).FirstOrDefaultAsync();
        public async Task<IEnumerable<User>> GetUsersAsync(bool trackChanges)
            => await FindAll(trackChanges).OrderBy(u => u.FirstName).ToListAsync();
        public void DeleteUser(User user) => Delete(user);
    }
}
