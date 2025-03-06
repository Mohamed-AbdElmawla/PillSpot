using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class PharmacyRequestRepository : RepositoryBase<PharmacyRequest>, IPharmacyRequestRepository
    {
        public PharmacyRequestRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePharmacyRequest(PharmacyRequest request) => Create(request);
        public void DeletePharmacyRequest(PharmacyRequest request) => Delete(request);

        public async Task<PharmacyRequest> GetByIdAsync(ulong id, bool trackChanges) =>
           await FindByCondition(pr => pr.RequestId.Equals(id), trackChanges).SingleOrDefaultAsync();
        public async Task<IEnumerable<PharmacyRequest>> GetByStatusAsync(string userId, PharmacyRequestStatus status, bool trackChanges) =>
           await FindByCondition(pr => pr.UserId.Equals(userId) && pr.Status.Equals(status), trackChanges).ToListAsync();

        public async Task<PagedList<PharmacyRequest>> GetRequestsAsync(PharmacyRequestParameters pharmacyRequestParameters,bool trackChanges) {
            var PharmacyRequests = await FindAll(trackChanges)
                .Sort(pharmacyRequestParameters.OrderBy)
                .Skip((pharmacyRequestParameters.PageNumber - 1) * pharmacyRequestParameters.PageSize)
                .Take(pharmacyRequestParameters.PageSize)
                .Include(pr => pr.Location)
                .Include(pr => pr.Location.City)
                .Include(pr => pr.Location.City.Government)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<PharmacyRequest>(PharmacyRequests, count, pharmacyRequestParameters.PageNumber, pharmacyRequestParameters.PageSize);
        }


        public async Task UpdateAsync(PharmacyRequest request) => Update(request);
    }
}
