using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<Notification>> GetUserNotificationsAsync(string userId, NotificationRequestParameters notificationRequestParameters, bool trackChanges)
        {
            var notifications = await FindByCondition(n => n.ActorId.Equals(userId) && !n.IsDeleted, trackChanges)
                .FilterByReadStatus(notificationRequestParameters.IsNotified)
                .Sort(notificationRequestParameters.OrderBy)
                .Skip((notificationRequestParameters.PageNumber - 1) * notificationRequestParameters.PageSize)
                .Take(notificationRequestParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(n => n.ActorId.Equals(userId) && !n.IsDeleted, trackChanges)
                .FilterByReadStatus(notificationRequestParameters.IsNotified)
                .CountAsync();

            return new PagedList<Notification>(notifications, count, notificationRequestParameters.PageNumber, notificationRequestParameters.PageSize);
        }

        public void CreateNotification(Notification notification) => Create(notification);

        public void DeleteNotification(Notification notification)
        {
            notification.IsDeleted = true;
            Update(notification);
        }
        public async Task<Notification> GetNotificationByIdAsync(Guid notificationId, bool trackChanges)=>
            await FindByCondition(n => n.NotificationId.Equals(notificationId), trackChanges).FirstOrDefaultAsync();

        public void UpdateNotification(Notification notification) => Update(notification);

        public async Task MarkAsNotifiedAsync(Guid notificationId, bool trackChanges)
        {
            var notification = await FindByCondition(n => n.NotificationId == notificationId, trackChanges).SingleOrDefaultAsync();
            if (notification != null)
            {
                notification.IsNotified = true;
                notification.NotifiedDate = DateTime.UtcNow;
                Update(notification);
            }
        }
    }
}
