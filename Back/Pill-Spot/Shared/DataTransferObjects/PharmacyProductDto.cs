namespace Shared.DataTransferObjects
{
    public record PharmacyProductDto
    {
        public int Quantity { get; init; }
        public ProductDto ProductDto { get; init; }
        public PharmacyDto PharmacyDto { get; init; }
        public bool IsAvailable { get; init; }
        public int MinimumStockThreshold { get; init; }
        public DateTime? LastRestocked { get; init; }
    }
}