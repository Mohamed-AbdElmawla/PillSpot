using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CityNotFoundException: NotFoundException
    {
        public CityNotFoundException(Guid cityId) : base($"City with id: {cityId} was not found")
        {
            
        }

    }
}
