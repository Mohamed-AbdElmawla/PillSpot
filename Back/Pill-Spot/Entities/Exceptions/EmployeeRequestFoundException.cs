namespace Entities.Exceptions
{
    public sealed class EmployeeRequestFoundException : NotFoundException
    {
        public EmployeeRequestFoundException(Guid requestId):base($"Request with ID {requestId} not found.")
        {   
        }
    }
}