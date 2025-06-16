using Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IRealTimeNotificationService
    {
        Task SendNotificationAsync(string userId, NotificationDto notification);
        Task SendBulkNotificationAsync(IEnumerable<string> userIds, NotificationDto notification);
        Task SendNotificationReadAsync(string userId, Guid notificationId);
        Task SendAllNotificationsReadAsync(string userId);
        Task SendUnreadCountAsync(string userId, int count);
    }
} 