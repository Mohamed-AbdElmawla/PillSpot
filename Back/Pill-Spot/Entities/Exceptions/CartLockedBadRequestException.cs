using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartLockedException : BadRequestException
    {
        public CartLockedException(Guid cartId)
            : base($"Cart with ID {cartId} is locked and cannot be modified.") { }
    }
}
