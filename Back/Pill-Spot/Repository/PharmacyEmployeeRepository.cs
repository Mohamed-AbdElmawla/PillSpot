using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class PharmacyEmployeeRepository(RepositoryContext context) : RepositoryBase<PharmacyEmployee>(context), IPharmacyEmployeeRepository
    {
        public async Task<PagedList<PharmacyEmployee>> GetAllPharmacyEmployeesAsync(EmployeesParameters employeesParameters, bool trackChanges)
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
        public async Task<PagedList<PharmacyEmployee>> GetEmployeesByPharmacyIdAsync(Guid pharmacyId, EmployeesParameters employeesParameters, bool trackChanges)
        {
            var pharmacyEmployees = await FindByCondition(emp => emp.PharmacyId.Equals(pharmacyId), trackChanges)
                .Sort(employeesParameters.OrderBy)
                .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                .Take(employeesParameters.PageSize)
                .Include(pe => pe.Pharmacy)
                .ToListAsync();

            var count = await FindByCondition(emp => emp.PharmacyId.Equals(pharmacyId), trackChanges).CountAsync();

            return new PagedList<PharmacyEmployee>(pharmacyEmployees, count, employeesParameters.PageNumber, employeesParameters.PageSize);
        }
        //public async Task<PagedList<Pharmacy>> GetPharmaciesByEmployeeIdAsync(Guid employeeId, EmployeesParameters employeesParameters, bool trackChanges)
        //{
        //    var pharmacies = await FindByCondition(emp => emp.EmployeeId.Equals(employeeId), trackChanges)
        //        .Select(emp => emp.Pharmacy)
        //        .Distinct()
        //        .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
        //        .Take(employeesParameters.PageSize)
        //        .ToListAsync();

        //    var count = await FindByCondition(emp => emp.EmployeeId.Equals(employeeId), trackChanges)
        //        .Select(emp => emp.Pharmacy)
        //        .Distinct()
        //        .CountAsync();

        //    return new PagedList<Pharmacy>(pharmacies, count, employeesParameters.PageNumber, employeesParameters.PageSize);
        //}
        public async Task<PagedList<PharmacyEmployee>> GetUserPharmaciesAsync(string userId, EmployeesParameters employeesParameters, bool trackChanges)
        {
            var pharmacyEmployees = await FindByCondition(emp => emp.UserId.Equals(userId), trackChanges)
                .Sort(employeesParameters.OrderBy)
                .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                .Take(employeesParameters.PageSize)
                .Include(pe => pe.Pharmacy)
                .ToListAsync();

            var count = await FindByCondition(emp => emp.UserId.Equals(userId), trackChanges).CountAsync();

            return new PagedList<PharmacyEmployee>(pharmacyEmployees, count, employeesParameters.PageNumber, employeesParameters.PageSize);
        }
        public async Task<PharmacyEmployee> GetPharmacyEmployeeByIdAsync(Guid employeeId, bool trackChanges) =>
            await FindByCondition(emp => emp.EmployeeId.Equals(employeeId), trackChanges).SingleOrDefaultAsync();
        public async Task<Guid> GetEmployeeIdByUserIdAsync(string userId, bool trackChanges)
        {
            var employeeId = await FindByCondition(emp => emp.UserId.Equals(userId), trackChanges)
                .Select(emp => emp.EmployeeId)
                .SingleOrDefaultAsync();

            return employeeId;
        }
        public async Task<string> GetUserIdByEmployeeIdAsync(Guid employeeId, bool trackChanges)
        {
            var userId = await FindByCondition(emp => emp.EmployeeId.Equals(employeeId), trackChanges)
                .Select(emp => emp.UserId)
                .SingleOrDefaultAsync();

            return userId;
        }
   
        public void AddPharmacyEmployee(PharmacyEmployee employee) => Create(employee);
        public void UpdatePharmacyEmployee(PharmacyEmployee employee) => Update(employee);








        public async Task<PharmacyEmployee> GetEmployeeByIdAsync(Guid employeeId, bool trackChanges)
        {
            return await FindByCondition(e => e.EmployeeId.Equals(employeeId) && !e.IsDeleted, trackChanges)
                .Include(e => e.User)
                .Include(e => e.PharmacyEmployeePermissions)
                .Include(e => e.Pharmacy)
                .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<PharmacyEmployee>> GetEmployeesByPharmacyAsync(Guid pharmacyId, bool trackChanges)
        {
            return await FindByCondition(e => e.PharmacyId.Equals(pharmacyId) && !e.IsDeleted, trackChanges)
                .Include(e => e.User)
                .Include(e => e.PharmacyEmployeePermissions)
                .Include(e => e.Pharmacy)
                .ToListAsync();
        }

        public async Task<PharmacyEmployee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername, bool trackChanges)
        {
            return await FindByCondition(e => (e.User.Email.Equals(emailOrUsername) || e.User.UserName.Equals(emailOrUsername)) && !e.IsDeleted, trackChanges)
                .Include(e => e.User)
                .Include(e => e.PharmacyEmployeePermissions)
                .SingleOrDefaultAsync();
        }

        public void DeletePharmacyEmployee(PharmacyEmployee employee)
        {
            employee.IsDeleted = true;
            Update(employee);
        }
    }
}
