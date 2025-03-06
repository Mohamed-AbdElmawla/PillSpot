using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AdminPermissionRepository : RepositoryBase<AdminPermission>, IAdminPermissionRepository
    {
        public AdminPermissionRepository(RepositoryContext context) : base(context) { }

        public async Task<bool> AdminHasPermissionAsync(string adminId, int permissionId) => 
            await FindByCondition(ap => ap.AdminId.Equals(adminId) && 
            ap.PermissionId.Equals(permissionId), trackChanges: false)
            .AnyAsync();

        public async Task<bool> AdminHasAnyPermissionAsync(string adminId, IEnumerable<int> permissionIds) => 
            await FindByCondition(ap => ap.AdminId.Equals(adminId) && 
            permissionIds.Contains(ap.PermissionId), trackChanges: false).AnyAsync();

        public async Task AssignPermissionToAdminAsync(AdminPermission adminPermission)
        {
            Create(adminPermission);
            await Task.CompletedTask;
        }

        public async Task AssignPermissionsToAdminAsync(IEnumerable<AdminPermission> adminPermissions)
        {
            foreach (var adminPermission in adminPermissions) 
                Create(adminPermission);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<AdminPermission>> GetAdminPermissionsAsync(string adminId, bool trackChanges) => 
            await FindByCondition(ap => ap.AdminId.Equals(adminId), trackChanges)
            .Include(ap => ap.Permission)
            .ToListAsync();

        public async Task<IEnumerable<AdminPermission>> GetAdminPermissionsByIdsAsync(string adminId, IEnumerable<int> permissionIds, bool trackChanges) =>
            await FindByCondition(ap => ap.AdminId.Equals(adminId) && permissionIds.Contains(ap.PermissionId), trackChanges)
            .Include(ap => ap.Permission)
            .ToListAsync();

        public void RemovePermissionFromAdmin(AdminPermission adminPermission) => Delete(adminPermission);

        public void RemovePermissionsFromAdmin(IEnumerable<AdminPermission> adminPermissions)
        {
            foreach (var adminPermission in adminPermissions)
                Delete(adminPermission);
        }
    }
}
