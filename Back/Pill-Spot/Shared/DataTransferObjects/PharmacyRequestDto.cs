using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Shared.DataTransferObjects
{
    public class PharmacyRequestDto
    {
        public ulong RequestID { get; init; }
        public string UserID { get; init; }
        public string PharmacistLicenseUrl { get; init; }
        public string Name { get; init; }
        public string? LogoURL { get; init; }
        public ulong LocationID { get; init; }
        public string LicenseID { get; init; }
        public string ContactNumber { get; init; }
        public TimeSpan OpeningTime { get; init; }
        public TimeSpan ClosingTime { get; init; }
        public bool IsOpen24 { get; init; }
        public string DaysOpen { get; init; }
        public PharmacyRequestStatus Status { get; init; }
        public string? AdminMessage { get; init; }
        public string? AdminUserID { get; init; }
        public DateTime RequestDate { get; init; }
        public DateTime? DecisionDate { get; init; }
    }
}
