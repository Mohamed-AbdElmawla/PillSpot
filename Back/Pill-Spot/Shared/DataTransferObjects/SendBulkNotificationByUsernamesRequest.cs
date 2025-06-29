using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record SendBulkNotificationByUsernamesRequest
    {
        public IEnumerable<string> Usernames { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public NotificationType Type { get; init; }
        public string? Data { get; init; }
    }
}
