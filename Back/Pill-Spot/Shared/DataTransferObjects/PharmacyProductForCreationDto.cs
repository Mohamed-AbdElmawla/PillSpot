namespace Shared.DataTransferObjects
{
    public record PharmacyProductForCreationDto
    {
        public ulong ProductId { get; init; }
        public ulong PharmacyId { get; init; }
        public ulong BatchId { get; init; }
        public int Quantity { get; init; }
    }
}