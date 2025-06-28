namespace Shared.DataTransferObjects
{
    public record CategoryDto
    {
        public Guid CategoryId { get; init; }
        public string Name { get; init; }
    }
}
