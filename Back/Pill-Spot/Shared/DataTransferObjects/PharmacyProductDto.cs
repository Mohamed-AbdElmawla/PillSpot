namespace Shared.DataTransferObjects
{
    public record PharmacyProductDto
    {
        public Guid ProductId { get; init; }
        public Guid PharmacyId { get; init; }
        public Guid BatchId { get; init; }
        public int Quantity { get; init; }
        public ProductDto Product { get; init; }
        public PharmacyDto Pharmacy { get; init; }
        public BatchDto Batch { get; init; }
    }
}