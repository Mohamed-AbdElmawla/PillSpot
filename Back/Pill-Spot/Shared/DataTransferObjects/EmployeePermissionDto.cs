namespace Shared.DataTransferObjects
{
    public record EmployeePermissionDto
    {
        public required ulong EmployeeID { get; init; }
        public int PermissionID { get; init; }
        public required string PermissionName { get; init; }
    }
}