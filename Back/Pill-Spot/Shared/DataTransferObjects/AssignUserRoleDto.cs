namespace Shared.DataTransferObjects
{
    public record AssignUserRoleDto
    {
        public required string UserId { get; init; }
        public required string Role { get; init; }
    }
}