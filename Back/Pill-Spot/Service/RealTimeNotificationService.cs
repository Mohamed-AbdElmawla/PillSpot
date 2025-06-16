using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using Service.Hubs;
using Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class RealTimeNotificationService : IRealTimeNotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public RealTimeNotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(string userId, NotificationDto notification)
        {
            await _hubContext.Clients.Group(userId).SendAsync("ReceiveNotification", notification);
        }

        public async Task SendBulkNotificationAsync(IEnumerable<string> userIds, NotificationDto notification)
        {
            foreach (var userId in userIds)
            {
                await SendNotificationAsync(userId, notification);
            }
        }

        public async Task SendNotificationReadAsync(string userId, Guid notificationId)
        {
            await _hubContext.Clients.Group(userId).SendAsync("NotificationRead", notificationId);
        }

        public async Task SendAllNotificationsReadAsync(string userId)
        {
            await _hubContext.Clients.Group(userId).SendAsync("AllNotificationsRead");
        }

        public async Task SendUnreadCountAsync(string userId, int count)
        {
            await _hubContext.Clients.Group(userId).SendAsync("ReceiveUnreadCount", count);
        }
    }
} 