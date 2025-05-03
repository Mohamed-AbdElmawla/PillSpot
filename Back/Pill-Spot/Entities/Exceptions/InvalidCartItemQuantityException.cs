using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class InvalidCartItemQuantityException : BadRequestException
    {
        public InvalidCartItemQuantityException(int quantity)
            : base($"Quantity: {quantity} is invalid. Must be greater than zero.") { }
    }
}
