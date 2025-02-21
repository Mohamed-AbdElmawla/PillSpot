    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PasswordChangeFailedException : BadRequestException
    {
        public PasswordChangeFailedException(string message) : base(message) { }
    }

}
