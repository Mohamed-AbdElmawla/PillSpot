namespace Shared.DataTransferObjects
{
    public record PharmacyProductDto
    {
        public int Quantity { get; init; }
        public ProductDto ProductDto { get; init; }
        public PharmacyDto PharmacyDto { get; init; }
    }
}