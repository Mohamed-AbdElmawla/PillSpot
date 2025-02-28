namespace Shared.DataTransferObjects
{
    public record BulkUserManagementDto
    {
        public List<string> UserIds { get; init; } = new();
        public string Action { get; init; } = string.Empty;
    }
}