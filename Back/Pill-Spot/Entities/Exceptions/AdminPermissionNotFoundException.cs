namespace Entities.Exceptions
{
    public class AdminPermissionNotFoundException : NotFoundException
    {
        public AdminPermissionNotFoundException(string adminId)
            : base($"No permissions found for Admin with ID: {adminId}.")
        { }

        public AdminPermissionNotFoundException(string adminId, int permissionId)
            : base($"Permission with ID: {permissionId} not found for Admin with ID: {adminId}.")
        { }
    }
}
