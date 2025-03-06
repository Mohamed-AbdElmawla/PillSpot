using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userName) : base($"User with userName: {userName} was not found")
        {

        }
        public UserNotFoundException(int UserId) : base($"User with UserId: {UserId} was not found")
        {

        }
    }
}
