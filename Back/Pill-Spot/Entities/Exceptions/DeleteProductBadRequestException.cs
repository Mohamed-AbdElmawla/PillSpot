namespace Entities.Exceptions
{
    public sealed class DeleteProductBadRequestException : BadRequestException
    {
        public DeleteProductBadRequestException() : base("At least one product ID is required.") { }
    }
}