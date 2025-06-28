using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IEmployeePermissionRepository
    {
        Task<PagedList<PharmacyEmployeePermission>> GetAllEmployeePermissionsAsync(EmployeePermissionParameters permissionParameters, bool trackChanges);
        Task<bool> ExistsAsync(Guid employeeId, Guid permissionId, bool trackChanges);
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
