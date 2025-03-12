namespace Shared.DataTransferObjects
{
    public class PermissionDto
    {
        public Guid PermissionId { get; init; }
        public required string Name { get; init; }
    }
}