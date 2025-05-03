using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class DuplicateCartItemException : BadRequestException
    {
        public DuplicateCartItemException(Guid productId, Guid pharmacyId)
            : base($"Item with product: {productId} from pharmacy: {pharmacyId} " +
                  "already exists in the cart.")
        { }
    }
}
