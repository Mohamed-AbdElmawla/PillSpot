namespace Entities.Exceptions
{
    public class EployeePermissionNotFoundException : NotFoundException
    {
        public EployeePermissionNotFoundException(Guid employeeId)
            : base($"No permissions found for Employee with ID: {employeeId}.")
        { }

        public EployeePermissionNotFoundException(Guid employeeId, Guid permissionId)
            : base($"Permission with ID: {permissionId} not found for Employee with ID: {employeeId}.")
        { }
    }
}