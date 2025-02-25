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
    internal sealed class GovernmentRepository : RepositoryBase<Government>, IGovernmentRepository
    {
        public GovernmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<Government>> GetAllGovernmentsAsync(GovernmentRequestParameters governmentRequestParameters, bool trackChanges)
        {
            var governments = await FindAll(trackChanges)
                .Sort(governmentRequestParameters.OrderBy)
                .Skip((governmentRequestParameters.PageNumber - 1) * governmentRequestParameters.PageSize)
                .Take(governmentRequestParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<Government>(governments, count, governmentRequestParameters.PageNumber, governmentRequestParameters.PageSize);
        }

        public async Task<Government> GetGovernmentByIdAsync(Guid governmentId, bool trackChanges)
            => await FindByCondition(g => g.GovernmentId.Equals(governmentId), trackChanges).SingleOrDefaultAsync();

        public async Task<Government> GetGovernmentByNameAsync(string governmentName, bool trackChanges)
            => await FindByCondition(g => g.GovernmentName.Equals(governmentName), trackChanges).SingleOrDefaultAsync();

        public void CreateGovernment(Government government) => Create(government);
        public void DeleteGovernment(Government government) => Delete(government);
        public void UpdateGovernment(Government government) => Update(government);
    }
}
