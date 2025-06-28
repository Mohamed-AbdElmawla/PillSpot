using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyProductWithDistanceDto : PharmacyProductDto
    {
        public double Distance { get; set; }

    }
}
