namespace Entities.Exceptions
{
    public sealed class InvalidSerializeProductBadRequestException : BadRequestException
    {
        public InvalidSerializeProductBadRequestException() : base("Invalid Products JSON") { }
    }
}
