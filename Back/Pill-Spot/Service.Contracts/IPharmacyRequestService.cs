using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPharmacyRequestService
    {
        Task SubmitRequestAsync(string userName, PharmacyRequestCreateDto pharmacyRequestCreateDto, bool trackChanges);
        Task<(IEnumerable<PharmacyRequestDto> pharmacyRequests, MetaData metaData)> GetPendingRequestsAsync(PharmacyRequestParameters pharmacyRequestParameters, bool trackChanges);
        Task ApproveRequestAsync(Guid requestId, bool trackChanges);
        Task RejectRequestAsync(Guid requestId, bool trackChanges);

    }
}
