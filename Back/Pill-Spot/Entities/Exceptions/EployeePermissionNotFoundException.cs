namespace Entities.Exceptions
{
    public class EployeePermissionNotFoundException : NotFoundException
    {
        public EployeePermissionNotFoundException(ulong employeeId)
            : base($"No permissions found for Employee with ID: {employeeId}.")
        { }

        public EployeePermissionNotFoundException(ulong employeeId, int permissionId)
            : base($"Permission with ID: {permissionId} not found for Employee with ID: {employeeId}.")
        { }
    }
}