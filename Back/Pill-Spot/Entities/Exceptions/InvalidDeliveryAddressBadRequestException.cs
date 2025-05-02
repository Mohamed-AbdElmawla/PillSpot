using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class InvalidDeliveryAddressException : BadRequestException
    {
        public InvalidDeliveryAddressException(Guid addressId)
            : base($"Delivery address with ID {addressId} is invalid or incompatible with the cart.") { }
    }
}