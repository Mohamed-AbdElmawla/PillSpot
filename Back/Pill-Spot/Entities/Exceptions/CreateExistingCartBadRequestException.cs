using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CreateExistingCartBadRequestException : BadRequestException
    {
        public CreateExistingCartBadRequestException(string userId):base($"Active cart already exists for user {userId}")
        {
            
        }
    }
}
