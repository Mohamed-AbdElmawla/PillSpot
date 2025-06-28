using Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IRealTimeNotificationService
    {
        Task SendNotificationAsync(string username, NotificationDto notification);
        Task SendBulkNotificationAsync(IEnumerable<string> usernames, NotificationDto notification);
        Task SendNotificationReadAsync(string username, Guid notificationId);
        Task SendAllNotificationsReadAsync(string username);
        Task SendUnreadCountAsync(string username, int count);
    }
} 