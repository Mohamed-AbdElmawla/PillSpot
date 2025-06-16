using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Threading.Tasks;

namespace Contracts
{
    public interface INotificationRepository
    {
        Task<PagedList<Notification>> GetUserNotificationsAsync(
            string userId,
            NotificationRequestParameters parameters,
            bool trackChanges);

        Task<Notification> GetNotificationByIdAsync(Guid id, bool trackChanges);
        void CreateNotification(Notification notification);
        void UpdateNotification(Notification notification);
        void DeleteNotification(Notification notification);
        Task MarkAsNotifiedAsync(Guid notificationId, bool trackChanges);
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(string userId);
        Task<int> GetUnreadNotificationCountAsync(string userId);
    }
}
