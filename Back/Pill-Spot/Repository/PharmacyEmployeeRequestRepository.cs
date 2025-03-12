using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal class PharmacyEmployeeRequestRepository(RepositoryContext context) : RepositoryBase<PharmacyEmployeeRequest>(context), IPharmacyEmployeeRequestRepository
    {
        public void CreateRequestToEmployee(PharmacyEmployeeRequest request) => Create(request);
        public void DeleteRequestToEmployee(PharmacyEmployeeRequest request) => Delete(request);
        public async Task<PharmacyEmployeeRequest> GetRequestToEmployeeByIdAsync(Guid requestId, bool trackChanges) =>
            await FindByCondition(req => req.RequestId.Equals(requestId), trackChanges).SingleOrDefaultAsync();
        public async Task<IEnumerable<PharmacyEmployeeRequest>> GetRequestToEmployeeByStatusAsync(string userId, RequestStatus status, bool trackChanges) =>
            await FindByCondition(req => req.UserId.Equals(userId) && req.Status.Equals(status), trackChanges).ToListAsync();
    }
}
