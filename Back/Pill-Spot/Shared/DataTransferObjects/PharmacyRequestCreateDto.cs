using Entities.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyRequestCreateDto
    {
        [Required(ErrorMessage = "Pharmacy name is required.")]
        [MaxLength(255, ErrorMessage = "Pharmacy name cannot exceed 255 characters.")]
        public string Name { get; init; }
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png", ".pdf" })]
        [Required(ErrorMessage = "Pharmacist license is required.")]
        [MaxFileSize(3 * 1024 * 1024)]
        public IFormFile PharmacistLicense { get; init; }

        [Required(ErrorMessage = "Location is required.")]
        public LocationForCreationDto Location { get; init; }

        [Required(ErrorMessage = "License ID is required.")]
        [MaxLength(450, ErrorMessage = "License ID cannot exceed 450 characters.")]
        public string LicenseId { get; init; }

        [Required(ErrorMessage = "Contact number is required.")]
        [MaxLength(11, ErrorMessage = "Contact number cannot exceed 11 characters.")]
        public string ContactNumber { get; init; }

        [Required(ErrorMessage = "Opening time is required.")]
        public TimeSpan? OpeningTime { get; init; }

        [Required(ErrorMessage = "Closing time is required.")]
        public TimeSpan? ClosingTime { get; init; }

        [Required(ErrorMessage = "IsOpen24 is required.")]
        public bool IsOpen24 { get; init; }

        [Required(ErrorMessage = "Days open is required.")]
        [MaxLength(50)]
        public string DaysOpen { get; init; }
        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(1 * 1024 * 1024)]
        public IFormFile? logo { get; init; }
    }
}
