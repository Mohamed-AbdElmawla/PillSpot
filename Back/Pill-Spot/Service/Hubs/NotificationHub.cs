using Microsoft.AspNetCore.SignalR;
using Service.Contracts;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Service.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly INotificationService _notificationService;
        private readonly IRealTimeNotificationService _realTimeNotificationService;

        public NotificationHub(
            INotificationService notificationService,
            IRealTimeNotificationService realTimeNotificationService)
        {
            _notificationService = notificationService;
            _realTimeNotificationService = realTimeNotificationService;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userId);
                var unreadCount = await _notificationService.GetUnreadNotificationCountAsync(userId);
                await _realTimeNotificationService.SendUnreadCountAsync(userId, unreadCount);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task MarkNotificationAsRead(Guid notificationId)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await _notificationService.MarkNotificationAsReadAsync(notificationId);
            }
        }

        public async Task MarkAllNotificationsAsRead()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await _notificationService.MarkAllNotificationsAsReadAsync(userId);
            }
        }
    }
} 