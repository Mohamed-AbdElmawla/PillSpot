using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPharmacyEmployeeRequestService
    {
        Task SendRequestAsync(PharmacyEmployeeRequestCreateDto requestDto, bool trackChanges);
        Task ApproveRequestAsync(Guid requestId, bool trackChanges);
        Task RejectRequestAsync(Guid requestId, bool trackChanges);
    }
}
