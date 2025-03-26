using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IPharmacyEmployeeRequestService
    {
        Task SendRequestAsync(PharmacyEmployeeRequestCreateDto requestDto,string userId, bool trackChanges);
        Task ApproveRequestAsync(Guid requestId, string currentUserId, bool trackChanges);
        Task RejectRequestAsync(Guid requestId, string currentUserId, bool trackChanges);
    }
}
