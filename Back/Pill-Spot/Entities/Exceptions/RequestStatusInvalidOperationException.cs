namespace Entities.Exceptions
{
    public sealed class RequestStatusBadRequestException : BadRequestException
    {
        public RequestStatusBadRequestException() : base("Request is not in a pending state.")
        {
        }
    }
}
