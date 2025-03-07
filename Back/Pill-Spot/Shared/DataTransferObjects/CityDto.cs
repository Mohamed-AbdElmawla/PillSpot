namespace Shared.DataTransferObjects
{
    public record CityDto
    {
        public required string CityName { get; init; }
        public GovernmentReferenceDto GovernmentReferenceDto { get; init; }
    }
}
