using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyForCreationDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; init; }
        public string? Logo { get; init; }

        [Required(ErrorMessage = "Please enter a valid phone number.")]
        [RegularExpression(@"^01[0-9]{9}$", ErrorMessage = "Please enter a valid Egyptian phone number.")]
        public string ContactNumber { get; init; }

        [Required(ErrorMessage = "LocationId is a required field.")]
        public int LocationId { get; init; }

        [Required(ErrorMessage = "OpeningHours is a required field.")]
        public string OpeningHours { get; init; }

        [Required(ErrorMessage = "IsOpen24Hours is a required field.")]
        public bool IsOpen24Hours { get; init; }

        [Required(ErrorMessage = "LicenseID is a required field.")]
        public string LicenseID { get; init; }
    }
}