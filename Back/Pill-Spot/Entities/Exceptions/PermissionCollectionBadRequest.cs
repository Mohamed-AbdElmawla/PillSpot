namespace Entities.Exceptions
{
    public class PermissionCollectionBadRequest : BadRequestException
    {
        public PermissionCollectionBadRequest() : base("Permission collection sent from a admin or SuperAdmin is null.") { }
    }
}
