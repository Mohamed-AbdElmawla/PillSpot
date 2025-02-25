using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPharmacyRequestRepository
    {
        void CreatePharmacyRequest(PharmacyRequest request);
        void DeletePharmacyRequest(PharmacyRequest request);
        Task<IEnumerable<PharmacyRequest>> GetByStatusAsync(string userId, PharmacyRequestStatus status, bool trackChanges);
        Task<PharmacyRequest> GetByIdAsync(ulong id, bool trackChanges);
        Task<PagedList<PharmacyRequest>> GetRequestsAsync(PharmacyRequestParameters pharmacyRequestParameters, bool trackChanges);
        Task UpdateAsync(PharmacyRequest request);
    }
}
