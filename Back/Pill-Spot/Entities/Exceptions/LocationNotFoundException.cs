using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class LocationNotFoundException: NotFoundException
    {
        public LocationNotFoundException(Guid locationID):base($"Location with id: {locationID} was not found")
        {
            
        }
    }
}
