using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PrescriptionRequiredException : BadRequestException
    {
        public PrescriptionRequiredException(Guid productId)
            : base($"Product: {productId} requires a prescription.") { }
    }
}
