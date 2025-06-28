namespace Shared.DataTransferObjects
{
    public record GovernmentDto
    {
        public required string GovernmentName { get; init; }
        public IEnumerable<CityDto> Cities { get; init; }
    }
}
