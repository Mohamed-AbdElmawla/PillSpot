namespace Shared.DataTransferObjects
{
    public record PharmacyDto
    {
        public string PharmacyId { get; init; }
        public string Name { get; init; }
        public string? Logo { get; init; }
        public string ContactNumber { get; init; }
        public string OpeningHours { get; init; }
        public bool IsOpen24Hours { get; init; }
        public DateTime CreatedAt { get; set; }
        public string? LicenseID { get; init; }
        public string LocationId { get; init; }
    }
}