using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PharmacyForCreationDto
    {
        public ulong? ParentPharmacyID { get; init; }
        public string OwnerID { get; init; }
        public string Name { get; init; }
        public string? LogoURL { get; init; }
        public Guid LocationID { get; init; }
        public string LicenseID { get; init; }
        public string ContactNumber { get; init; }
        public TimeSpan OpeningTime { get; init; }
        public TimeSpan ClosingTime { get; init; }
        public bool IsOpen24 { get; init; }
        public string DaysOpen { get; init; }
    }
}
