namespace Shared.DataTransferObjects
{
    public record CreateAdminPermissionDto
    {
        public required string AdminID { get; init; }
        public int PermissionID { get; init; }
    }
}
