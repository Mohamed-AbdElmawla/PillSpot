namespace Shared.DataTransferObjects
{
    public record PrescriptionProductDto
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
        public string? Dosage { get; init; }
        public string? Instructions { get; init; }
        public ProductDto Product { get; init; }
    }
}
