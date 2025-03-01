using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record LocationForCreationDto
    {
        [Required(ErrorMessage = "Longitude is required.")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
        public double Longitude { get; init; }

        [Required(ErrorMessage = "Latitude is required.")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
        public double Latitude { get; init; }

        [Required(ErrorMessage = "Additional information is required.")]
        [MaxLength(250, ErrorMessage = "Additional information cannot exceed 250 characters.")]
        public string AdditionalInfo { get; init; }

        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(250, ErrorMessage = "City name cannot exceed 250 characters.")]
        public string CityName { get; init; }

        [Required(ErrorMessage = "Government name is required.")]
        [MaxLength(250, ErrorMessage = "Government name cannot exceed 250 characters.")]
        public string GovernmentName { get; init; }
    }
}
