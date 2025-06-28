using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal sealed class AdminPermissionRepository : RepositoryBase<AdminPermission>, IAdminPermissionRepository
    {
        public AdminPermissionRepository(RepositoryContext context) : base(context) { }
        public async Task<bool> ExistsAsync(string adminId, Guid permissionId) =>
           await FindByCondition(p => p.AdminId.Equals(adminId) && p.PermissionId.Equals(permissionId), false)
               .AnyAsync();
        public async Task<bool> AdminHasAnyPermissionAsync(string adminId, IEnumerable<Guid> permissionIds) =>
            await FindByCondition(ap => ap.AdminId.Equals(adminId) &&
            permissionIds.Contains(ap.PermissionId), trackChanges: false).AnyAsync();

        public void AssignPermissionToAdminAsync(AdminPermission adminPermission) => Create(adminPermission);

        public void AssignPermissionsToAdminAsync(IEnumerable<AdminPermission> adminPermissions)
        {
            foreach (var adminPermission in adminPermissions)
                Create(adminPermission);
        }

        public async Task<IEnumerable<AdminPermission>> GetAdminPermissionsAsync(string adminId, bool trackChanges) =>
            await FindByCondition(ap => ap.AdminId.Equals(adminId), trackChanges)
            .Include(ap => ap.Permission)
            .ToListAsync();
        public async Task<AdminPermission> GetAdminPermissionAsync(string adminId, Guid permissionId, bool trackChanges) =>
           await FindByCondition(ap => ap.AdminId.Equals(adminId) && ap.PermissionId.Equals(permissionId), trackChanges)
            .FirstOrDefaultAsync();
        public async Task<IEnumerable<AdminPermission>> GetAdminPermissionsByIdsAsync(string adminId, IEnumerable<Guid> permissionIds, bool trackChanges) =>
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
