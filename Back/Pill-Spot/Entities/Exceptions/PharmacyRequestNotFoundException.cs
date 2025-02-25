using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PharmacyRequestNotFoundException: NotFoundException
    {
        public PharmacyRequestNotFoundException(ulong requestId) : base($"Pharmacy request with id: {requestId} not found")
        {
            
        }
    }
}
