using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class InvalidCartTypeException : BadRequestException
    {
        public InvalidCartTypeException(string cartType)
            : base($"Cart type '{cartType}' is invalid. Must be 'User' or 'Guest'.") { }
    }
}