using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyForCreationDto
    {
        public string Name { get; init; }
        public string? Logo { get; init; }
        public string ContactNumber { get; init; }
        public int LocationId { get; init; }
        public string OpeningHours { get; init; }
        public bool IsOpen24Hours { get; init; }
        public string? LicenseID { get; init; }
    }
}