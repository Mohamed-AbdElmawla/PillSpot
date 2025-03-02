namespace Shared.DataTransferObjects
{
    public record UpdateAdminPermissionsDto
    {
        public required string AdminId { get; init; }
        public List<int> PermissionIds { get; init; } = new();
    }
}