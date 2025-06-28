using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartDeactivatedException : BadRequestException
    {
        public CartDeactivatedException(Guid cartId)
            : base($"Cart with id: {cartId} is deactivated and cannot be accessed.") { }
    }
}
