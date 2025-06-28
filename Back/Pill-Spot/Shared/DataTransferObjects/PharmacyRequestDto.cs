using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record PharmacyRequestDto
    {
        public Guid RequestId { get; init; }
        public string Name { get; init; }
        public string? LogoURL { get; init; }
        public LocationDto LocationDto { get; init; }
        public string LicenseId { get; init; }
        public string ContactNumber { get; init; }
        public TimeSpan OpeningTime { get; init; }
        public TimeSpan ClosingTime { get; init; }
        public bool IsOpen24 { get; init; }
        public string DaysOpen { get; init; }
        public PharmacyRequestStatus Status { get; init; }
        public string? AdminMessage { get; init; }
        public DateTime RequestDate { get; init; }
        public DateTime? DecisionDate { get; init; }
    }
}
