namespace Shared.DataTransferObjects
{
    public record AssignEmployeePermissionDto
    {
        public ulong EmployeeId { get; init; }
        public int PermissionId { get; init; }
    }
}
