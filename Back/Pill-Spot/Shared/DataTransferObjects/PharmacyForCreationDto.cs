namespace Shared.DataTransferObjects
{
    public record PharmacyForCreationDto
    {
        public Guid? ParentPharmacyId { get; init; }
        public required string OwnerId { get; init; }
        public required string Name { get; init; }
        public string? LogoURL { get; init; }
        public Guid LocationId { get; init; }
        public required string LicenseId { get; init; }
        public required string ContactNumber { get; init; }
        public TimeSpan OpeningTime { get; init; }
        public TimeSpan ClosingTime { get; init; }
        public bool IsOpen24 { get; init; }
        public required string DaysOpen { get; init; }
    }
}
