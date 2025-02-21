using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class InvalidPasswordException : BadRequestException
    {
        public InvalidPasswordException() : base("The provided old password is incorrect.") { }
    }
}
