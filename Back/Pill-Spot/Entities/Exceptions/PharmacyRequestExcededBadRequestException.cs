using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PharmacyRequestExcededBadRequestException : BadRequestException
    {
        public PharmacyRequestExcededBadRequestException()
            :base("You cannot create a new pharmacy because you already own two.")
        {
            
        }
    }
}
