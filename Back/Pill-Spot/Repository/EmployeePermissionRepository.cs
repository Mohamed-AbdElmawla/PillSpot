using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class EmployeePermissionRepository(RepositoryContext context) : RepositoryBase<PharmacyEmployeePermission>(context), IEmployeePermissionRepository
    {
        public async Task<PagedList<PharmacyEmployeePermission>> GetAllEmployeePermissionsAsync(EmployeePermissionParameters employeePermissionParameters, bool trackChanges)
        {
            var employeePermissions = await FindAll(trackChanges)
                .OrderBy(p => p.Permission.Name)
                .Skip((employeePermissionParameters.PageNumber - 1) * employeePermissionParameters.PageSize)
                .Take(employeePermissionParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<PharmacyEmployeePermission>(employeePermissions, count, employeePermissionParameters.PageNumber, employeePermissionParameters.PageSize);
        }
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
        public async Task<bool> ExistsAsync(Guid employeeId, Guid permissionId, bool trackChanges) =>
          await FindByCondition(p => p.EmployeeId.Equals(employeeId) && p.PermissionId.Equals(permissionId), trackChanges)
              .AnyAsync();
    }

}
