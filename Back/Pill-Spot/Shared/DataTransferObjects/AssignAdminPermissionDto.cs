namespace Shared.DataTransferObjects
{
    public record AssignAdminPermissionDto
    {
        public required string AdminId { get; init; }  // Keep as string for ASP.NET Identity
        public Guid PermissionId { get; init; }
    }
}
