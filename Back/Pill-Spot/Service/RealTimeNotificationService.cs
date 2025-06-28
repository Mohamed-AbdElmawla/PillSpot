using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using Service.Hubs;
using Shared.DataTransferObjects;
using System;
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

        public async Task SendNotificationAsync(string username, NotificationDto notification)
        {
            await _hubContext.Clients.Group(username).SendAsync("ReceiveNotification", notification);
        }

        public async Task SendBulkNotificationAsync(IEnumerable<string> usernames, NotificationDto notification)
        {
            foreach (var username in usernames)
            {
                await SendNotificationAsync(username, notification);
            }
        }

        public async Task SendNotificationReadAsync(string username, Guid notificationId)
        {
            await _hubContext.Clients.Group(username).SendAsync("NotificationRead", notificationId);
        }

        public async Task SendAllNotificationsReadAsync(string username)
        {
            await _hubContext.Clients.Group(username).SendAsync("AllNotificationsRead");
        }

        public async Task SendUnreadCountAsync(string username, int count)
        {
            await _hubContext.Clients.Group(username).SendAsync("ReceiveUnreadCount", count);
        }
    }
} 