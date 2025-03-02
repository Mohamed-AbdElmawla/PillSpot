namespace Shared.DataTransferObjects
{
    public record CreateAdminPermissionDto
    {
        public required string AdminId { get; init; }
        public int PermissionId { get; init; }
    }
}
