using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class UserEmailNotFoundException : NotFoundException  
    {
        public UserEmailNotFoundException(string email) : base($"User with email: {email} was not found")
        {
            
        }
    }
}
