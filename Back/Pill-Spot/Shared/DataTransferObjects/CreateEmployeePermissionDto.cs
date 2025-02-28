namespace Shared.DataTransferObjects
{
    public record CreateEmployeePermissionDto
    {
        public required ulong EmployeeID { get; init; }
        public int PermissionID { get; init; }
    }
}