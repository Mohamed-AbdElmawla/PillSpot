using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IGovernmentService
    {
        Task<Guid> CreateGovernmentAsync(GovernmentForCreationDto government, bool trackChanges);
        Task DeleteGovernmentAsync(Guid governmentId, bool trackChanges);
        Task<(IEnumerable<GovernmentDto> governments, MetaData metaData)> GetAllGovernmentsAsync(GovernmentRequestParameters governmentRequestParameters, bool trackChanges);
        Task<GovernmentDto> GetGovernmentByIdAsync(Guid governmentId, bool trackChanges);
        Task UpdateGovernmentAsync(Guid governmentId, GovernmentForCreationDto government, bool trackChanges);
    }
}
