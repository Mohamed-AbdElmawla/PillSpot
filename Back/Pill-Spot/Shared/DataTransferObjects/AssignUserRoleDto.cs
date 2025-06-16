namespace Shared.DataTransferObjects
{
    public record AssignUserRoleDto
    {
        public required string UserId { get; init; }  // Keep as string for ASP.NET Identity
        public required string Role { get; init; }
    }
}