using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record CosmeticDto : ProductDto
    {
        public required string Brand { get; init; }
        public SkinType SkinType { get; init; }
        public required string UsageInstructions { get; init; }
        public int Volume { get; init; }
    }
}