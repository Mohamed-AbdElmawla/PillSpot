namespace Shared.DataTransferObjects
{
    public record EmployeePermissionDto
    {
        public required ulong EmployeeId { get; init; }
        public int PermissionId { get; init; }
        public required string PermissionName { get; init; }
    }
}