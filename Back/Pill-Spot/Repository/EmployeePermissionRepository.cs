using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EmployeePermissionRepository : RepositoryBase<PharmacyEmployeePermission>, IEmployeePermissionRepository
    {
        public EmployeePermissionRepository(RepositoryContext context) : base(context) { }

        public async Task<bool> EmployeeHasPermissionAsync(Guid employeeId, Guid permissionId) =>
          await FindByCondition(ap => ap.EmployeeId.Equals(employeeId) &&
          ap.PermissionId.Equals(permissionId), trackChanges: false)
          .AnyAsync();

        public async Task<bool> EmployeeHasAnyPermissionAsync(Guid employeeId, IEnumerable<Guid> permissionIds) =>
            await FindByCondition(ap => ap.EmployeeId.Equals(employeeId) &&
            permissionIds.Contains(ap.PermissionId), trackChanges: false).AnyAsync();

        public void AssignPermissionToEmployeeAsync(PharmacyEmployeePermission employeePermission) => Create(employeePermission);

        public void AssignPermissionsToEmployeeAsync(IEnumerable<PharmacyEmployeePermission> employeePermissions)
        {
            foreach (var employeePermission in employeePermissions)
                Create(employeePermission);
        }

        public async Task<IEnumerable<PharmacyEmployeePermission>> GetEmployeePermissionsAsync(Guid employeeId, bool trackChanges)
        {
            var employeePermissions = await FindByCondition(ap => ap.EmployeeId.Equals(employeeId), trackChanges)
                .Include(ap => ap.Permission)
                .ToListAsync();
            return employeePermissions;
        }
        public async Task<IEnumerable<PharmacyEmployeePermission>> GetEmployeePermissionsByIdsAsync(Guid employeeId, IEnumerable<Guid> permissionIds, bool trackChanges) =>
          await FindByCondition(ap => ap.EmployeeId.Equals(employeeId) && permissionIds.Contains(ap.PermissionId), trackChanges)
          .Include(ap => ap.Permission)
          .ToListAsync();
        public void RemovePermissionFromEmployee(PharmacyEmployeePermission employeePermission) => Delete(employeePermission);

        public void RemovePermissionsFromEmployee(IEnumerable<PharmacyEmployeePermission> employeePermissions)
        {
            foreach (var employeePermission in employeePermissions)
                Delete(employeePermission);
        }
        public async Task<string?> GetUserIdByEmployeeIdAsync(Guid employeeId) =>
            await FindByCondition(ep => ep.EmployeeId.Equals(employeeId), trackChanges: false)
            .Include(e => e.PharmacyEmployee)
            .Select(e => e.PharmacyEmployee.UserId)
            .FirstOrDefaultAsync();
    }

}
