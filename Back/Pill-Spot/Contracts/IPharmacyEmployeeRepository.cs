using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPharmacyEmployeeRepository
    {
        Task<PagedList<PharmacyEmployee>> GetAllPharmacyEmployeeAsync(EmployeesParameters employeesParameters, bool trackChanges);
        Task<PharmacyEmployee> GetPharmacyEmployeeByIdAsync(Guid employeeId, bool trackChanges);
        void AddPharmacyEmployeeAsync(PharmacyEmployee employee);
        void DeletePharmacyEmployee(PharmacyEmployee employee);
    }
}
