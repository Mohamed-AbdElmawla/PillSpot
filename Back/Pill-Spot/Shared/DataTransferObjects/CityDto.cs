using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CityDto
    {
        public string CityName { get; init; }
        public GovernmentDto GovernmentDto { get; init; }
    }
}
