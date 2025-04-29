using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeePermissionService
    {
        Task<EmployeePermissionDto> AssignPermissionToEmployeeAsync(AssignEmployeePermissionDto assignEmployeePermissionDto);
        Task<IEnumerable<EmployeePermissionDto>> AssignPermissionsToEmployeeAsync(Guid employeeId, IEnumerable<Guid> permissionIds);
        Task<IEnumerable<PermissionDto>> GetPermissionsToEmployeeAsync(Guid EmployeeId, bool trackChanges);
        Task<Guid> GetEmployeeIdByUserIdAsync(string userId, bool trackChanges);
        Task RemovePermissionFromEmployeeAsync(Guid EmployeeId, Guid permissionId);
        Task RemovePermissionsFromEmployeeAsync(Guid EmployeeId, IEnumerable<Guid> permissionIds);
        Task<bool> HasPermissionAsync(string userId, string requiredPermission, bool isAdminCheck = false);
        Task<bool> EmployeeHasPermissionAsync(Guid employeeId, string permissionName, bool trackChanges);
    }

}
