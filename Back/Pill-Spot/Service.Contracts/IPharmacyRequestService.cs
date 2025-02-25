using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPharmacyRequestService
    {
        Task SubmitRequestAsync(string userName, PharmacyRequestCreateDto pharmacyRequestCreateDto, bool trackChanges);
        Task<(IEnumerable<PharmacyRequestDto> pharmacyRequests, MetaData metaData)> GetPendingRequestsAsync(PharmacyRequestParameters pharmacyRequestParameters, bool trackChanges);
        Task ApproveRequestAsync(ulong requestId, bool trackChanges);
        Task RejectRequestAsync(ulong requestId, bool trackChanges);

    }
}
