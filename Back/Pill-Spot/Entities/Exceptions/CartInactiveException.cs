using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartInactiveException : BadRequestException
    {
        public CartInactiveException(Guid cartId)
            : base($"Cart with id: {cartId} is inactive. Activate it before modifications.") { }
    }
}
