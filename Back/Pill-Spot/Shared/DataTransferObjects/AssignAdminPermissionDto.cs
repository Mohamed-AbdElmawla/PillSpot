namespace Shared.DataTransferObjects
{
    public record AssignAdminPermissionDto
    {
        public required string AdminId { get; init; }
        public int PermissionId { get; init; }
    }
}
