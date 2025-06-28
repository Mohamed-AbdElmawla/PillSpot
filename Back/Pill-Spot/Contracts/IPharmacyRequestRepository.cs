using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPharmacyRequestRepository
    {
        void CreatePharmacyRequest(PharmacyRequest request);
        void DeletePharmacyRequest(PharmacyRequest request);
        Task<IEnumerable<PharmacyRequest>> GetByStatusAsync(string userId, PharmacyRequestStatus status, bool trackChanges);
        Task<PharmacyRequest> GetByIdAsync(Guid pharmacyRequestId, bool trackChanges);
        Task<PagedList<PharmacyRequest>> GetRequestsAsync(PharmacyRequestParameters pharmacyRequestParameters, bool trackChanges);
        void UpdateRequest(PharmacyRequest request);
    }
}
