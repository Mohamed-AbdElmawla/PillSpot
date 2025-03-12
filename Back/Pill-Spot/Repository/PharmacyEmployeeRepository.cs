using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class PharmacyEmployeeRepository(RepositoryContext context) : RepositoryBase<PharmacyEmployee>(context), IPharmacyEmployeeRepository
    {
        public async Task<PagedList<PharmacyEmployee>> GetAllPharmacyEmployeeAsync(EmployeesParameters employeesParameters, bool trackChanges)
        {
            var pharmacyEmployees = await FindAll(trackChanges)
                .Sort(employeesParameters.OrderBy)
                .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                .Take(employeesParameters.PageSize)
                .Include(pe => pe.Pharmacy)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<PharmacyEmployee>(pharmacyEmployees, count, employeesParameters.PageNumber, employeesParameters.PageSize);
        }
        public async Task<PharmacyEmployee> GetPharmacyEmployeeByIdAsync(Guid employeeId, bool trackChanges) =>
            await FindByCondition(emp => emp.EmployeeId.Equals(employeeId), trackChanges).SingleOrDefaultAsync();
        public async Task<PagedList<PharmacyEmployee>> GetUserPharmaciesAsync(string userId, EmployeesParameters employeesParameters, bool trackChanges) {
            var pharmacyEmployees = await FindByCondition(emp => emp.UserId.Equals(userId), trackChanges)
                .Sort(employeesParameters.OrderBy)
                .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                .Take(employeesParameters.PageSize)
                .Include(pe => pe.Pharmacy)
                .ToListAsync();

            var count = await FindByCondition(emp => emp.UserId.Equals(userId), trackChanges).CountAsync();

            return new PagedList<PharmacyEmployee>(pharmacyEmployees, count, employeesParameters.PageNumber, employeesParameters.PageSize);
        }
        public void AddPharmacyEmployeeAsync(PharmacyEmployee employee) => Create(employee);
        public void DeletePharmacyEmployee(PharmacyEmployee employee) => Delete(employee);
    }
}
