using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyForCreationDto
    {
        public ulong? ParentPharmacyId { get; init; }
        public string OwnerId { get; init; }
        public string Name { get; init; }
        public string? LogoURL { get; init; }
        public Guid LocationId { get; init; }
        public string LicenseId { get; init; }
        public string ContactNumber { get; init; }
        public TimeSpan OpeningTime { get; init; }
        public TimeSpan ClosingTime { get; init; }
        public bool IsOpen24 { get; init; }
        public string DaysOpen { get; init; }
    }
}
