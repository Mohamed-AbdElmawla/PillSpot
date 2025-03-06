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
    public record PharmacyForUpdateDto
    {

        [MaxLength(255, ErrorMessage = "Name cannot exceed 255 characters.")]
        public string? Name { get; init; }

        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(1 * 1024 * 1024)]
        public IFormFile? logo { get; init; }

        [MaxLength(11, ErrorMessage = "Contact number cannot exceed 11 characters.")]
        public string? ContactNumber { get; init; }
        public TimeSpan? OpeningTime { get; init; }
        public TimeSpan? ClosingTime { get; init; }
        public bool? IsOpen24 { get; init; }

        [MaxLength(50, ErrorMessage = "Days open description cannot exceed 50 characters.")]
        public string? DaysOpen { get; init; }
    }
}
