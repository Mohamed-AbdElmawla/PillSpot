using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects
{
    public record PharmacyDto
    {
        public Guid PharmacyId { get; init; }
        public string Name { get; init; }
        public string? LogoURL { get; init; }
        public IFormFile? logo { get; init; }
        public LocationDto LocationDto { get; init; }
        public string ContactNumber { get; init; }
        public TimeSpan OpeningTime { get; init; }
        public TimeSpan ClosingTime { get; init; }
        public bool IsOpen24 { get; init; }
        public string DaysOpen { get; init; }
    }
}
