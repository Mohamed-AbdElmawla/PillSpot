namespace Shared.DataTransferObjects
{
    public record PharmacyProductForCreationDto
    {
        public Guid ProductId { get; init; }
        public Guid PharmacyId { get; init; }
        public Guid BatchId { get; init; }
        public int Quantity { get; init; }
    }
}