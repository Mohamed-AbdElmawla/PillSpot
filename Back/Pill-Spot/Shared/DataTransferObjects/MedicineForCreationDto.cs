namespace Shared.DataTransferObjects
{
    public record MedicineForCreationDto : ProductForCreationDto
    {
        public required string Manufacturer { get; init; }
        public float Dosage { get; init; }
        public required string SideEffects { get; init; }
        public bool IsPrescriptionRequired { get; init; }
    }
}
