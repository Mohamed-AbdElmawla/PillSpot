namespace Shared.DataTransferObjects
{
    public record AdminPermissionDto
    {
        public required string AdminId { get; init; }  // Keep as string for ASP.NET Identity
        public Guid PermissionId { get; init; }
        public required string PermissionName { get; init; }
    }
}