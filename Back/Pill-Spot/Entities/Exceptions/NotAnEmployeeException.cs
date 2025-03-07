namespace Entities.Exceptions
{
    public class NotAnEmployeeException : NotAuthorizedException
    {
        public NotAnEmployeeException(string employeeId)
            : base($"User with ID '{employeeId}' is not an pharmacy employee.") { }
    }
}