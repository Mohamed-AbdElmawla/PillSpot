using Entities.Models;

namespace Contracts
{
    public interface IAdminPermissionRepository
    {
        Task<bool> AdminHasAnyPermissionAsync(string adminId, IEnumerable<Guid> permissionIds);
        void AssignPermissionToAdminAsync(AdminPermission adminPermission);
        void AssignPermissionsToAdminAsync(IEnumerable<AdminPermission> adminPermissions);
        Task<AdminPermission> GetAdminPermissionAsync(string adminId, Guid permissionId, bool trackChanges);
        Task<IEnumerable<AdminPermission>> GetAdminPermissionsAsync(string adminId, bool trackChanges);
        Task<IEnumerable<AdminPermission>> GetAdminPermissionsByIdsAsync(string adminId, IEnumerable<Guid> permissionIds, bool trackChanges);
        void RemovePermissionFromAdmin(AdminPermission adminPermission);
        void RemovePermissionsFromAdmin(IEnumerable<AdminPermission> adminPermissions);
    }
}