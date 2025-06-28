namespace Shared.DataTransferObjects
{
    public record MedicineForUpdateDto : ProductForUpdateDto
    {
        public float? Dosage { get; init; }
        public string? SideEffects { get; init; }
        public bool? IsPrescriptionRequired { get; init; }
    }
}
