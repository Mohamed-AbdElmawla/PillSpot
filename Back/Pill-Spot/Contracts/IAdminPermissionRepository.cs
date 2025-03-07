using Entities.Models;

namespace Contracts
{
    public interface IAdminPermissionRepository
    {
        Task<bool> AdminHasPermissionAsync(string adminId, Guid permissionId);
        Task<bool> AdminHasAnyPermissionAsync(string adminId, IEnumerable<Guid> permissionIds);
        void AssignPermissionToAdminAsync(AdminPermission adminPermission);
        void AssignPermissionsToAdminAsync(IEnumerable<AdminPermission> adminPermissions);
        Task<IEnumerable<AdminPermission>> GetAdminPermissionsAsync(string adminId, bool trackChanges);
        Task<IEnumerable<AdminPermission>> GetAdminPermissionsByIdsAsync(string adminId, IEnumerable<Guid> permissionIds, bool trackChanges);
        void RemovePermissionFromAdmin(AdminPermission adminPermission);
        void RemovePermissionsFromAdmin(IEnumerable<AdminPermission> adminPermissions);
    }
}