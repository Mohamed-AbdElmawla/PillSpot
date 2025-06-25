namespace Entities.Exceptions
{
    public sealed class AddProductBadRequestException : BadRequestException
    {
        public AddProductBadRequestException() : base("At least one product is required.") { }
    }
}