using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class BatchNotFoundException : NotFoundException
    {
        public BatchNotFoundException(ulong productId, ulong pharmacyId)
            : base($"Batch for ProductId: {productId} and PharmacyId: {pharmacyId} was not found.")
        {
        }
    }
}
