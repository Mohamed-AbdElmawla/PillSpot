using System.Linq;
using System.Linq.Dynamic.Core;
using Entities.Models;
using Repository.Utility;

namespace Repository.Extentions
{
    public static class NotificationRepositoryExtensions
    {
        public static IQueryable<Notification> Sort(this IQueryable<Notification> notifications, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return notifications.OrderBy(n => n.CreatedDate);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Notification>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return notifications.OrderBy(n => n.CreatedDate);

            return notifications.OrderBy(orderQuery);
        }
        
        public static IQueryable<Notification> FilterByReadStatus(this IQueryable<Notification> notifications, bool? isRead)
        {
            if (!isRead.HasValue)
                return notifications;

            return notifications.Where(n => n.IsRead == isRead.Value);
        }
        
        public static IQueryable<Notification> FilterByNotifiedStatus(this IQueryable<Notification> notifications, bool? isNotified)
        {
            if (!isNotified.HasValue)
                return notifications;

            return notifications.Where(n => n.IsNotified == isNotified.Value);
        }
        
        public static IQueryable<Notification> FilterByType(this IQueryable<Notification> notifications, NotificationType? type)
        {
            if (!type.HasValue)
                return notifications;

            return notifications.Where(n => n.Type == type.Value);
        }
    }
}
