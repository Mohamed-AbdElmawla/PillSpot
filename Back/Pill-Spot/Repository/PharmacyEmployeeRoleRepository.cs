using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    internal sealed class PharmacyEmployeeRoleRepository(RepositoryContext context) : RepositoryBase<PharmacyEmployeeRole>(context),IPharmacyEmployeeRoleRepository
    {
        public void AddPharmacyEmployeeRole(PharmacyEmployeeRole employeeRole) => Create(employeeRole);

        public async Task<bool> ExistsAsync(string userId, string roleName, Guid pharmacyId, bool trackChanges) =>
            await FindByCondition(p => p.Employee.UserId.Equals(userId) && 
             p.Role.Name.Equals(roleName) && 
             p.PharmacyId.Equals(pharmacyId), trackChanges)
            .Include(p => p.Role)
            .AnyAsync();
        public async Task<PharmacyEmployeeRole?> GetRoleByEmployeeIdAsync(Guid employeeId,bool trackChanges) =>
           await FindByCondition(r => r.EmployeeId.Equals(employeeId), false)
               .Include(r => r.Role)
               .FirstOrDefaultAsync();
    }

}
