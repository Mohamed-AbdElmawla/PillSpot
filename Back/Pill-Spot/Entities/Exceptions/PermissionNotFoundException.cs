namespace Entities.Exceptions
{
    public class PermissionNotFoundException : NotFoundException
    {
        public PermissionNotFoundException(int permissionId)
            : base($"Permission with id: {permissionId} was not found.")
        {
        }
    }
}