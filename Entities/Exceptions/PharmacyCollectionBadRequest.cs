using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PharmacyCollectionBadRequest : BadRequestException
    {
        public PharmacyCollectionBadRequest():base("Pharmacy collection sent from a client is null.")
        {
            
        }
    }
}
