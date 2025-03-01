using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGovernmentRepository
    {
        Task<PagedList<Government>> GetAllGovernmentsAsync(GovernmentRequestParameters governmentRequestParameters, bool trackChanges);
        Task<Government> GetGovernmentByIdAsync(Guid governmentId, bool trackChanges);
        Task<Government> GetGovernmentByNameAsync(string governmentName, bool trackChanges);
        void CreateGovernment(Government government);
        void DeleteGovernment(Government government);
        void UpdateGovernment(Government government);
    }
}
