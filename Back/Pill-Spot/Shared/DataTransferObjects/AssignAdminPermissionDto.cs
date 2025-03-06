namespace Shared.DataTransferObjects
{
    public record AssignAdminPermissionDto
    {
        public string AdminId { get; init; }
        public int PermissionId { get; init; }
    }
}
