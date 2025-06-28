namespace Entities.Exceptions
{
    public class PermissionNotFoundException : NotFoundException
    {
        public PermissionNotFoundException(Guid permissionId)
            : base($"Permission with id: {permissionId} was not found.")
        {
        }
    }
}