using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record LocationForUpdateDto(
        [Required(ErrorMessage = "Longitude is required")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        double Longitude,

        [Required(ErrorMessage = "Latitude is required")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        double Latitude,

        [Required(ErrorMessage = "Additional information is required")]
        [MaxLength(250, ErrorMessage = "Additional info cannot exceed 250 characters")]
        string AdditionalInfo,

        [Required(ErrorMessage = "City ID is required")]
        Guid CityId);
}
