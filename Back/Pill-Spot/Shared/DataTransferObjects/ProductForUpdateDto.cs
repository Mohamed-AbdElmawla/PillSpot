using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects
{
    public record ProductForUpdateDto
    {
        public Guid? SubCategoryId { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? UsageInstructions { get; init; }
        public double? Price { get; init; }
        public IFormFile? Image { get; init; }
    }
}
