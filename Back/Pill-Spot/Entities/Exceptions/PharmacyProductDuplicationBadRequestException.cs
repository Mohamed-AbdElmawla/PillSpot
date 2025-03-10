using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PharmacyProductDuplicationBadRequestException: BadRequestException
    {
        public PharmacyProductDuplicationBadRequestException(Guid pharmacyId, Guid productId)
            :base($"The pharmacy with id: {pharmacyId} already have a product with id: {productId}")

        {
                
        }
    }
}
