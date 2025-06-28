namespace Shared.DataTransferObjects
{
    public record MedicineDto : ProductDto
    {
        public float Dosage { get; init; }
        public string SideEffects { get; init; }
        public bool IsPrescriptionRequired { get; init; }
    }
}
