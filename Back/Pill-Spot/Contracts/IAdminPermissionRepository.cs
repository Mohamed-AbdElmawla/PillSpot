using Entities.Models;

namespace Contracts
{
    public interface IAdminPermissionRepository
    {
        Task AssignPermissionToAdminAsync(AdminPermission adminPermission);
        Task AssignPermissionsToAdminAsync(IEnumerable<AdminPermission> adminPermissions);
        Task<IEnumerable<AdminPermission>> GetAdminPermissionsAsync(string adminId, bool trackChanges);
        void RemovePermissionFromAdmin(AdminPermission adminPermission);
        void RemovePermissionsFromAdmin(IEnumerable<AdminPermission> adminPermissions);
    }
}