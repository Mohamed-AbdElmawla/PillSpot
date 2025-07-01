using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class UserNotAuthorizedException : NotAuthorizedException
    {
        public UserNotAuthorizedException()
            : base($"You are not authorized to do any thing with this data") { }
    }
}
