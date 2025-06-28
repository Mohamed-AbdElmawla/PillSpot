namespace Shared.DataTransferObjects
{
    public record AssignEmployeePermissionDto
    {
        public Guid EmployeeId { get; init; }
        public Guid PermissionId { get; init; }
    }
}
