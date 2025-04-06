using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Threading.Tasks;

namespace Contracts
{
    public interface INotificationRepository
    {
        Task<PagedList<Notification>> GetUserNotificationsAsync(string userId, NotificationRequestParameters notificationRequestParameters, bool trackChanges);
        Task<Notification> GetNotificationByIdAsync(Guid notificationId, bool trackChanges);
        void CreateNotification(Notification notification);
        void DeleteNotification(Notification notification);
        void UpdateNotification(Notification notification);
        Task MarkAsNotifiedAsync(Guid notificationId, bool trackChanges);
    }
}
