using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userName, bool trackChanges);
        Task<IEnumerable<User>> GetUsersAsync(bool trackChanges);
        void DeleteUser(User user);

    }
}
