using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class EmailUpdateFailedException : Exception
    {
        public EmailUpdateFailedException(string message) : base(message) { }
    }
}
