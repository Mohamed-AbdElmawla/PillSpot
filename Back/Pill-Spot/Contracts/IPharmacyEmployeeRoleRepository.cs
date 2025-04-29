using Entities.Models;

namespace Contracts
{
    public interface IPharmacyEmployeeRoleRepository
    {
        void AddPharmacyEmployeeRole(PharmacyEmployeeRole employee);
        Task<bool> ExistsAsync(string userId, string roleName, Guid pharmacyId,bool trackChanges);
        Task<PharmacyEmployeeRole?> GetRoleByEmployeeIdAsync(Guid employeeId, bool trackChanges);
    }
}
