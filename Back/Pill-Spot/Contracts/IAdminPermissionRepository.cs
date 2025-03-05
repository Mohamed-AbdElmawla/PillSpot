using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IAdminPermissionRepository
    {
        Task<bool> AdminHasPermissionAsync(string adminId, int permissionId);
        Task<bool> AdminHasAnyPermissionAsync(string adminId, IEnumerable<int> permissionIds);
        Task AssignPermissionToAdminAsync(AdminPermission adminPermission);
        Task AssignPermissionsToAdminAsync(IEnumerable<AdminPermission> adminPermissions);
        Task<IEnumerable<AdminPermission>> GetAdminPermissionsAsync(string adminId, bool trackChanges);
        Task<IEnumerable<AdminPermission>> GetAdminPermissionsByIdsAsync(string adminId, IEnumerable<int> permissionIds, bool trackChanges);
        void RemovePermissionFromAdmin(AdminPermission adminPermission);
        void RemovePermissionsFromAdmin(IEnumerable<AdminPermission> adminPermissions);
    }
}