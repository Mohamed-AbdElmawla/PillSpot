namespace Entities.Exceptions
{
    public sealed class AdminPermissionCollectionBadRequestException : BadRequestException
    {
        public AdminPermissionCollectionBadRequestException()
            : base("Admin permission collection is null or empty.")
        { }
    }
}
