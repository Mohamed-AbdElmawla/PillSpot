using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAdminPermissionService
    {
        Task<bool> AdminHasPermissionAsync(string adminId, string permissionName, bool trackChanges);
        Task<AdminPermissionDto> AssignPermissionToAdminAsync(AssignAdminPermissionDto assignAdminPermissionDto, bool trackChanges);
        Task<IEnumerable<AdminPermissionDto>> AssignPermissionsToAdminAsync(string adminId, IEnumerable<Guid> permissionIds);
        Task<IEnumerable<PermissionDto>> GetPermissionsToAdminAsync(string adminId, bool trackChanges);
        Task RemovePermissionFromAdminAsync(string adminId, Guid permissionId);
        Task RemovePermissionsFromAdminAsync(string adminId, IEnumerable<Guid> permissionIds);
        Task<bool> HasPermissionAsync(string userId, string requiredPermission, bool isAdminCheck = true);
    }
}
