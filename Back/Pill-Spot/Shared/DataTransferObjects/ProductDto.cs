namespace Shared.DataTransferObjects
{
    public record ProductDto
    {
        public Guid ProductId { get; init; }
        public SubCategoryDto subCategoryDto { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public string ImageURL { get; init; }
        public DateTime CreatedDate { get; init; }
    }
}
