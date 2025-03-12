namespace Shared.DataTransferObjects
{
    public record BulkUserManagementDto
    {
        public required List<string> UserIds { get; init; }
        public required string Action { get; init; }
    }
}