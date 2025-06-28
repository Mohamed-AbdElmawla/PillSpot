using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPharmacyEmployeeRepository
    {
        Task<PharmacyEmployee?> GetByUserAndPharmacyAsync(string userId, Guid pharmacyId, bool trackChanges);
        Task<PagedList<PharmacyEmployee>> GetAllPharmacyEmployeesAsync(EmployeesParameters employeesParameters, bool trackChanges);
        Task<PagedList<PharmacyEmployee>> GetEmployeesByPharmacyIdAsync(Guid pharmacyId, EmployeesParameters employeesParameters, bool trackChanges);
        //Task<PagedList<Pharmacy>> GetPharmaciesByEmployeeIdAsync(Guid employeeId, EmployeesParameters employeesParameters, bool trackChanges);
        Task<PagedList<Pharmacy>> GetUserPharmaciesAsync(string userId, EmployeesParameters employeesParameters, bool trackChanges);
        //Task<PagedList<PharmacyEmployee>> GetUserPharmaciesAsync(string userId, EmployeesParameters employeesParameters, bool trackChanges);
        Task<Guid> GetEmployeeIdByUserIdAsync(string userId, bool trackChanges);
        Task<string> GetUserIdByEmployeeIdAsync(Guid employeeId, bool trackChanges);
        Task<PharmacyEmployee> GetPharmacyEmployeeByIdAsync(Guid employeeId, bool trackChanges);
        void AddPharmacyEmployee(PharmacyEmployee employee);
        void UpdatePharmacyEmployee(PharmacyEmployee employee);






        Task<PharmacyEmployee> GetEmployeeByIdAsync(Guid employeeId, bool trackChanges);
        Task<IEnumerable<PharmacyEmployee>> GetEmployeesByPharmacyAsync(Guid pharmacyId, bool trackChanges);
        Task<PharmacyEmployee> GetEmployeeByEmailOrUsernameAsync(string emailOrUsername, bool trackChanges);
        void DeletePharmacyEmployee(PharmacyEmployee employee);
    }
}
