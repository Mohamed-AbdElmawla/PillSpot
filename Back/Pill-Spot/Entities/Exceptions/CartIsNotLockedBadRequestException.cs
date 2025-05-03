using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartIsNotLockedBadRequestException: BadRequestException
    {
        public CartIsNotLockedBadRequestException(Guid cartId):base($"Cart with ID {cartId} is not locked")
        {
            
        }
    }
}
