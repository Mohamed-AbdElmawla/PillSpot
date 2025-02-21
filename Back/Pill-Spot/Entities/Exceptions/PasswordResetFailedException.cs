using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PasswordResetFailedException : Exception
    {
        public PasswordResetFailedException(string message):base(message)
        {
            
        }
    }
}
