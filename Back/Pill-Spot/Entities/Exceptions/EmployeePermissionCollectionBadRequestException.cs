namespace Entities.Exceptions
{
    public class EmployeePermissionCollectionBadRequestException : BadRequestException
    {
        public EmployeePermissionCollectionBadRequestException()
            : base("Employee permission collection is null or empty.")
        { }
    }
}