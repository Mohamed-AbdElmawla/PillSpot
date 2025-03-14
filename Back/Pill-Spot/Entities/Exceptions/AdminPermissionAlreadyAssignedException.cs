namespace Entities.Exceptions
{
    public sealed class AdminPermissionAlreadyAssignedException : Exception
    {
        public AdminPermissionAlreadyAssignedException(string adminId, IEnumerable<Guid> permissionIds)
            : base($"Admin with ID {adminId} already has one of the assigned permissions: {string.Join(", ", permissionIds.Select(id=>id.ToString()))}.")
        {
        }
    }
}