using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPharmacyEmployeeRequestService
    {
        Task SendRequestAsync(PharmacyEmployeeRequestCreateDto requestDto);
        Task ApproveRequestAsync(Guid requestId);
        Task RejectRequestAsync(Guid requestId);
    }
}
