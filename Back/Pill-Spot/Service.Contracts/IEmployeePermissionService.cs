using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEmployeePermissionService
    {
        Task<EmployeePermissionDto> AssignPermissionToEmployeeAsync(AssignEmployeePermissionDto assignEmployeePermissionDto);
        Task<IEnumerable<EmployeePermissionDto>> AssignPermissionsToEmployeeAsync(Guid employeeId, IEnumerable<Guid> permissionIds);
        Task<IEnumerable<PermissionDto>> GetPermissionsToEmployeeAsync(Guid adminId, bool trackChanges);
        Task RemovePermissionFromEmployeeAsync(Guid EmployeeId, Guid permissionId);
        Task RemovePermissionsFromEmployeeAsync(Guid EmployeeId, IEnumerable<Guid> permissionIds);
    }

}
