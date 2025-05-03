using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPharmacyEmployeeRequestRepository
    {
        void CreateRequestToEmployee(PharmacyEmployeeRequest request);
        Task<PharmacyEmployeeRequest> GetRequestToEmployeeByIdAsync(Guid requestId, bool trackChanges);
        Task<IEnumerable<PharmacyEmployeeRequest>> GetRequestToEmployeeByStatusAsync(string userId, Guid pharmacyId, RequestStatus status, bool trackChanges);
        Task<IEnumerable<PharmacyEmployeeRequest>> GetRequestsByPharmacyIdAsync(Guid pharmacyId, bool trackChanges);
        Task<PagedList<PharmacyEmployeeRequest>> GetRequestsAsync(EmployeesRequestParameters employeesRequestParameters,string userId, bool trackChanges);
        void DeleteRequestToEmployee(PharmacyEmployeeRequest request);
    }
}
