using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Entities.Models;

namespace Service.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly IServiceManager _serviceManager;
        private readonly IRealTimeNotificationService _realTimeNotificationService;
        private readonly UserManager<User> _userManager;

        public NotificationHub(
            IServiceManager serviceManager,
            IRealTimeNotificationService realTimeNotificationService,
            UserManager<User> userManager)
        {
            _serviceManager = serviceManager;
            _realTimeNotificationService = realTimeNotificationService;
            _userManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            var username = Context.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, username);
                var unreadCount = await _serviceManager.NotificationService.GetUnreadNotificationCountByUsernameAsync(username);
                await _realTimeNotificationService.SendUnreadCountAsync(username, unreadCount);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var username = Context.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, username);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task MarkNotificationAsRead(Guid notificationId)
        {
            var username = Context.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    var notification = await _serviceManager.NotificationService.GetNotificationByIdAsync(notificationId, false);
                    var notificationUsername = await GetUsernameFromUserIdAsync(notification.UserId);
                    if (notificationUsername == username)
                    {
                        await _serviceManager.NotificationService.MarkNotificationAsReadAsync(notificationId, username);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error marking notification as read: {ex.Message}");
                }
            }
        }

        public async Task MarkAllNotificationsAsRead()
        {
            var username = Context.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                await _serviceManager.NotificationService.MarkAllNotificationsAsReadByUsernameAsync(username);
            }
        }

        private async Task<string> GetUsernameFromUserIdAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                return user?.UserName ?? userId;
            }
            catch
            {
                return userId;
            }
        }
    }
} 