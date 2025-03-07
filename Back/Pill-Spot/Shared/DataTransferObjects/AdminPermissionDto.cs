namespace Shared.DataTransferObjects
{
    public record AdminPermissionDto
    {
        public required string AdminId { get; init; }
        public Guid PermissionId { get; init; }
        public required string PermissionName { get; init; }
    }
}