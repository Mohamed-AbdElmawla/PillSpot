using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record CosmeticForUpdateDto : ProductForUpdateDto
    {
        public string Brand { get; init; }
        public SkinType SkinType { get; init; }
        public string UsageInstructions { get; init; }
        public int Volume { get; init; }
    }
}
