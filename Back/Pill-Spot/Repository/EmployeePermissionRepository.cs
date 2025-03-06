using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EmployeePermissionRepository : RepositoryBase<PharmacyEmployeePermission>, IEmployeePermissionRepository
    {
        public EmployeePermissionRepository(RepositoryContext context) : base(context) { }

        public async Task AssignPermissionToEmployeeAsync(PharmacyEmployeePermission employeePermission)
        {
            Create(employeePermission);
            await Task.CompletedTask;
        }

        public async Task AssignPermissionsToEmployeeAsync(IEnumerable<PharmacyEmployeePermission> employeePermissions)
        {
            foreach (var employeePermission in employeePermissions)
                Create(employeePermission);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<PharmacyEmployeePermission>> GetEmployeePermissionsAsync(ulong employeeId, bool trackChanges)
        {
            var employeePermissions = await FindByCondition(ap => ap.EmployeeId == employeeId, trackChanges)
                .Include(ap => ap.Permission)
                .ToListAsync();
            return employeePermissions;
        }

        public void RemovePermissionFromEmployee(PharmacyEmployeePermission employeePermission) => Delete(employeePermission);

        public void RemovePermissionsFromEmployee(IEnumerable<PharmacyEmployeePermission> employeePermissions)
        {
            foreach (var employeePermission in employeePermissions)
                Delete(employeePermission);
        }
    }

}
