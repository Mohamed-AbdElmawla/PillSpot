using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAdminPermissionService
    {
        Task<AdminPermissionDto> AssignPermissionToAdminAsync(AssignAdminPermissionDto assignAdminPermissionDto);
        Task<IEnumerable<AdminPermissionDto>> AssignPermissionsToAdminAsync(string adminId, IEnumerable<Guid> permissionIds);
        Task<IEnumerable<PermissionDto>> GetPermissionsToAdminAsync(string adminId, bool trackChanges);
        Task RemovePermissionFromAdminAsync(string adminId, Guid permissionId);
        Task RemovePermissionsFromAdminAsync(string adminId, IEnumerable<Guid> permissionIds);
    }
}
