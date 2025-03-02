namespace Shared.DataTransferObjects
{
    public record AssignUserRoleDto
    {
        public string UserId { get; init; }
        public string Role { get; init; }
    }
}