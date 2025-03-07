namespace Shared.DataTransferObjects
{
    public record BatchDto
    {
        public Guid BatchId { get; init; }
        public required string BatchNumber { get; init; }
        public DateTime ManufactureDate { get; init; }
        public DateTime ExpirationDate { get; init; }
    }
}