using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
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
        
        public async Task<PagedList<User>> GetUsersAsync(UserParameters userParameters, bool trackChanges)
        {
            var users = await FindAll(trackChanges)
                .Sort(userParameters.OrderBy)
                .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
                .Take(userParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<User>(users, count, userParameters.PageNumber, userParameters.PageSize);
        }

        public void DeleteUser(User user) => Delete(user);
    }
}
