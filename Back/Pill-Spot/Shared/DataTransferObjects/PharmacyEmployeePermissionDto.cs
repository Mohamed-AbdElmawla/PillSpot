namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeePermissionDto
    {
        public required Guid EmployeeId { get; init; }
        public Guid PermissionId { get; init; }
        public required string PermissionName { get; init; }
    }
}