using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AdminPermissionRepository : RepositoryBase<AdminPermission>, IAdminPermissionRepository
    {
        public AdminPermissionRepository(RepositoryContext context) : base(context) { }

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

        public async Task<IEnumerable<AdminPermission>> GetAdminPermissionsAsync(string adminId, bool trackChanges)
        {
            var adminPermissions = await FindByCondition(ap => ap.AdminId == adminId, trackChanges)
                .Include(ap => ap.Permission)
                .ToListAsync();
            return adminPermissions;
        }

        public void RemovePermissionFromAdmin(AdminPermission adminPermission) => Delete(adminPermission);

        public void RemovePermissionsFromAdmin(IEnumerable<AdminPermission> adminPermissions)
        {
            foreach (var adminPermission in adminPermissions)
                Delete(adminPermission);
        }
    }
}
