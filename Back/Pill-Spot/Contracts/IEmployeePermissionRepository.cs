using Entities.Models;

namespace Contracts
{
    public interface IEmployeePermissionRepository
    {
        Task<bool> EmployeeHasPermissionAsync(Guid employeeId, Guid permissionId);
        Task<bool> EmployeeHasAnyPermissionAsync(Guid employeeId, IEnumerable<Guid> permissionIds);
        //Task<string?> GetUserIdByEmployeeIdAsync(Guid employeeId);
        Task<IEnumerable<PharmacyEmployeePermission>> GetEmployeePermissionsByIdsAsync(Guid employeeId, IEnumerable<Guid> permissionIds, bool trackChanges);
        void AssignPermissionToEmployeeAsync(PharmacyEmployeePermission employeePermission);
        void AssignPermissionsToEmployeeAsync(IEnumerable<PharmacyEmployeePermission> employeePermissions);
        Task<IEnumerable<PharmacyEmployeePermission>> GetEmployeePermissionsAsync(Guid employeeId, bool trackChanges);
        void RemovePermissionFromEmployee(PharmacyEmployeePermission employeePermission);
        void RemovePermissionsFromEmployee(IEnumerable<PharmacyEmployeePermission> employeePermissions);
    }
}
