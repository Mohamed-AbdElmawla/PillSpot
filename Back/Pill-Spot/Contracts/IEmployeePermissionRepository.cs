using Entities.Models;

namespace Contracts
{
    public interface IEmployeePermissionRepository
    {
        Task AssignPermissionToEmployeeAsync(PharmacyEmployeePermission employeePermission);
        Task AssignPermissionsToEmployeeAsync(IEnumerable<PharmacyEmployeePermission> employeePermissions);
        Task<IEnumerable<PharmacyEmployeePermission>> GetEmployeePermissionsAsync(ulong employeeId, bool trackChanges);
        void RemovePermissionFromEmployee(PharmacyEmployeePermission employeePermission);
        void RemovePermissionsFromEmployee(IEnumerable<PharmacyEmployeePermission> employeePermissions);
    }
}
