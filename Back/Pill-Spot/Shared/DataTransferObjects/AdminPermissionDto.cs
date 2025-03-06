namespace Shared.DataTransferObjects
{
    public record AdminPermissionDto
    {
        public required string AdminID { get; init; }
        public int PermissionID { get; init; }
        public required string PermissionName { get; init; }
    }
}