using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeRequestDto
    {
        public Guid RequestId { get; init; }
        public string UserId { get; init; }  // Keep as string for ASP.NET Identity
        public string RequesterId { get; init; }  // Keep as string for ASP.NET Identity
        public Guid PharmacyId { get; init; }
        public RequestStatus Status { get; init; }
        public DateTime RequestDate { get; init; }
    }
}
