namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeRequestCreateDto
    {
        public Guid PharmacyId { get; init; }
        public required string UserName { get; init; }
        public required string RoleName { get; init; }
        public IEnumerable<string>? Permissions { get; init; }
    }
}
