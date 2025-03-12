using Entities.Models;

namespace Contracts
{
    public interface IPharmacyEmployeeRequestRepository
    {
        void CreateRequestToEmployee(PharmacyEmployeeRequest request);
        Task<PharmacyEmployeeRequest> GetRequestToEmployeeByIdAsync(Guid requestId, bool trackChanges);
        Task<IEnumerable<PharmacyEmployeeRequest>> GetRequestToEmployeeByStatusAsync(string userId, RequestStatus status, bool trackChanges);
        void DeleteRequestToEmployee(PharmacyEmployeeRequest request);
    }
}
