using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeRequestDto
    {
        public Guid RequestId { get; init; }
        public string UserId { get; init; }
        public string RequesterId { get; init; }
        public Guid PharmacyId { get; init; }
        public RequestStatus Status { get; init; }
        public DateTime RequestDate { get; init; }
        public string RoleName { get; init; }
        public IEnumerable<string>? Permissions { get; init; }
    }
}
