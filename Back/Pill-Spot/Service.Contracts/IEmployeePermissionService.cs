using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeePermissionService
    {
        Task<EmployeePermissionDto> AssignPermissionToEmployeeAsync(AssignEmployeePermissionDto assignEmployeePermissionDto);
        Task<IEnumerable<EmployeePermissionDto>> AssignPermissionsToEmployeeAsync(ulong employeeId, IEnumerable<int> permissionIds);
        Task<IEnumerable<PermissionDto>> GetPermissionsToEmployeeAsync(ulong adminId, bool trackChanges);
        Task RemovePermissionFromEmployeeAsync(ulong EmployeeId, int permissionId);
        Task RemovePermissionsFromEmployeeAsync(ulong EmployeeId, IEnumerable<int> permissionIds);
    }

}
