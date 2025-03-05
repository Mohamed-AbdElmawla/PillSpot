namespace Entities.Exceptions
{
    public class AdminPermissionAlreadyAssignedException : Exception
    {
        public AdminPermissionAlreadyAssignedException(string adminId, IEnumerable<int> permissionIds)
            : base($"Admin with ID {adminId} already has one of the assigned permissions: {string.Join(", ", permissionIds)}.")
        {
        }
    }
}