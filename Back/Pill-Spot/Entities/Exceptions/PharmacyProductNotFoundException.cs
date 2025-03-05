using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PharmacyProductNotFoundException : NotFoundException
    {
        public PharmacyProductNotFoundException(ulong productId, ulong pharmacyId)
            : base($"PharmacyProduct with PharmacyId: {pharmacyId} and ProductId: {productId} was not found.")
        {
        }
    }
}
