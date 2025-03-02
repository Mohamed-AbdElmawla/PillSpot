namespace Shared.DataTransferObjects
{
    public record CreateEmployeePermissionDto
    {
        public required ulong EmployeeId { get; init; }
        public int PermissionId { get; init; }
    }
}