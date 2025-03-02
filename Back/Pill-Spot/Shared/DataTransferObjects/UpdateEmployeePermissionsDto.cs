namespace Shared.DataTransferObjects
{
    public class UpdateEmployeePermissionsDto
    {
        public required ulong EmployeeId { get; init; }
        public List<int> PermissionIds { get; init; } = new();
    }
}
