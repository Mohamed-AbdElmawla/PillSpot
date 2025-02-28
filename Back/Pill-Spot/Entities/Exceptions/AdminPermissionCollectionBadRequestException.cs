namespace Entities.Exceptions
{
    public class AdminPermissionCollectionBadRequestException : BadRequestException
    {
        public AdminPermissionCollectionBadRequestException()
            : base("Admin permission collection is null or empty.")
        { }
    }
}
