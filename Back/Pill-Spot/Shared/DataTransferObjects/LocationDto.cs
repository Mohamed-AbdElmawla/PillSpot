using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class LocationDto
    {
        public double Longitude { get; init; }

        public double Latitude { get; init; }

        public string AdditionalInfo { get; init; }

        public CityDto CityDto { get; init; }
    }
}
