namespace Entities.Exceptions
{
    public sealed class RequestFoundException : NotFoundException
    {
        public RequestFoundException(Guid requestId) : base($"Request with ID {requestId} not found.")
        {
        }
    }
}