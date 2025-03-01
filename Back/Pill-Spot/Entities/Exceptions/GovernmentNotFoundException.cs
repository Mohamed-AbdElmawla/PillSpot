using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class GovernmentNotFoundException: NotFoundException
    {
        public GovernmentNotFoundException(Guid governmentId):base($"Government with id: {governmentId} was not found")
        {
            
        }
    }
}
