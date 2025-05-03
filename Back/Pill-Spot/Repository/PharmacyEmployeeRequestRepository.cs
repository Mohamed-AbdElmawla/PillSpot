using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class PharmacyEmployeeRequestRepository(RepositoryContext context) : RepositoryBase<PharmacyEmployeeRequest>(context), IPharmacyEmployeeRequestRepository
    {
        public void CreateRequestToEmployee(PharmacyEmployeeRequest request) => Create(request);
        public void DeleteRequestToEmployee(PharmacyEmployeeRequest request) => Delete(request);
        public async Task<PharmacyEmployeeRequest> GetRequestToEmployeeByIdAsync(Guid requestId, bool trackChanges) =>
            await FindByCondition(req => req.RequestId.Equals(requestId), trackChanges).SingleOrDefaultAsync();
        public async Task<IEnumerable<PharmacyEmployeeRequest>> GetRequestToEmployeeByStatusAsync(string userId,Guid pharmacyId ,RequestStatus status, bool trackChanges) =>
            await FindByCondition(req => req.UserId.Equals(userId) && req.Status.Equals(status) && req.PharmacyId.Equals(pharmacyId), trackChanges).ToListAsync();
        public async Task<IEnumerable<PharmacyEmployeeRequest>> GetRequestsByPharmacyIdAsync(Guid pharmacyId, bool trackChanges) =>
          await FindByCondition(req => req.PharmacyId.Equals(pharmacyId), trackChanges).ToListAsync();
        public async Task<PagedList<PharmacyEmployeeRequest>> GetRequestsAsync(EmployeesRequestParameters employeesRequestParameters,string userId, bool trackChanges)
        {
            var PharmacyEmployeeRequests = await FindByCondition(emp=>emp.UserId.Equals(userId),trackChanges)
                .Sort(employeesRequestParameters.OrderBy)
                .Skip((employeesRequestParameters.PageNumber - 1) * employeesRequestParameters.PageSize)
                .Take(employeesRequestParameters.PageSize)
                .Include(pr => pr.Pharmacy)
                .Include(pr => pr.User)
                .Include(pr => pr.Requester)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<PharmacyEmployeeRequest>(PharmacyEmployeeRequests, count, employeesRequestParameters.PageNumber, employeesRequestParameters.PageSize);
        }
    }
}
