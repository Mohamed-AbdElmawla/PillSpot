namespace Shared.DataTransferObjects
{
    public record SubCategoryDto
    {
        public CategoryDto CategoryDto { get; init; }
        public Guid SubCategoryId { get; init; }
        public string Name { get; init; }
    }
}
