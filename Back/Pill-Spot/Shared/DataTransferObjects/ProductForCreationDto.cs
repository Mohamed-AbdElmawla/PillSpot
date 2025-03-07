namespace Shared.DataTransferObjects
{
    public record ProductForCreationDto
    {
        public Guid SubCategoryId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
        public string ImageURL { get; init; }
    }
}
