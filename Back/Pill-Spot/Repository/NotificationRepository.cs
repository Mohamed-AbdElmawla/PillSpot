using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PagedList<Notification>> GetUserNotificationsAsync(
            string userId,
            NotificationRequestParameters parameters,
            bool trackChanges)
        {
            var notifications = await FindByCondition(n => n.UserId == userId && !n.IsDeleted, trackChanges)
                .FilterByReadStatus(parameters.IsNotified)
                .Sort(parameters.OrderBy)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(n => n.UserId == userId && !n.IsDeleted, trackChanges)
                .FilterByReadStatus(parameters.IsNotified)
                .CountAsync();

            return new PagedList<Notification>(notifications, count, parameters.PageNumber, parameters.PageSize);
        }

        public void CreateNotification(Notification notification)
        {
            Create(notification);
        }

        public void DeleteNotification(Notification notification)
        {
            Delete(notification);
        }

        public async Task<Notification> GetNotificationByIdAsync(Guid notificationId, bool trackChanges) =>
            await FindByCondition(n => n.NotificationId.Equals(notificationId), trackChanges).FirstOrDefaultAsync();

        public void UpdateNotification(Notification notification)
        {
            Update(notification);
        }

        public async Task MarkAsNotifiedAsync(Guid notificationId, bool trackChanges)
        {
            var notification = await FindByCondition(n => n.NotificationId == notificationId, trackChanges)
                .SingleOrDefaultAsync();
            if (notification != null)
            {
                notification.IsNotified = true;
                notification.NotifiedDate = DateTime.UtcNow;
                Update(notification);
            }
        }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(string userId)
        {
            return await FindByCondition(n => n.UserId == userId && !n.IsRead && !n.IsDeleted, false)
                .OrderByDescending(n => n.CreatedDate)
                .ToListAsync();
        }

        public async Task<int> GetUnreadNotificationCountAsync(string userId)
        {
            return await FindByCondition(n => n.UserId == userId && !n.IsRead && !n.IsDeleted, false)
                .CountAsync();
        }
    }
}
