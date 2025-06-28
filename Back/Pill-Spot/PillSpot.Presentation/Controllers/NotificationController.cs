using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Notifications;
using Shared.RequestFeatures;

namespace PillSpot.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NotificationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserNotifications([FromQuery] NotificationRequestParameters parameters)
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            var notifications = await _service.NotificationService.GetUserNotificationsByUsernameAsync(username, parameters, false);
            return Ok(notifications);
        }

        [HttpGet("user/{username}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> GetUserNotificationsByUsername(string username, [FromQuery] NotificationRequestParameters parameters)
        {
            var notifications = await _service.NotificationService.GetUserNotificationsByUsernameAsync(username, parameters, false);
            return Ok(notifications);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var notification = await _service.NotificationService.GetNotificationByIdAsync(id, false);
            return Ok(notification);
        }

        [HttpPost]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationForCreationByUsernameDto dto)
        {
            var notification = await _service.NotificationService.SendNotificationByUsernameAsync(
                dto.Username,
                dto.Title,
                dto.Message,
                dto.Type,
                dto.Data
            );
            return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationId }, notification);
        }

        [HttpDelete("{id:guid}")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeleteNotification(Guid id)
        {
            await _service.NotificationService.DeleteNotificationAsync(id, false);
            return NoContent();
        }

        [HttpPost("{id:guid}/read")]
        [ValidateCsrfToken]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            await _service.NotificationService.MarkNotificationAsReadAsync(id);
            return NoContent();
        }

        [HttpPost("read-all")]
        [ValidateCsrfToken]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            await _service.NotificationService.MarkAllNotificationsAsReadByUsernameAsync(username);
            return NoContent();
        }

        [HttpPost("user/{username}/read-all")]
        [ValidateCsrfToken]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> MarkAllAsReadByUsername(string username)
        {
            await _service.NotificationService.MarkAllNotificationsAsReadByUsernameAsync(username);
            return NoContent();
        }

        [HttpGet("unread/count")]
        public async Task<IActionResult> GetUnreadCount()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            var count = await _service.NotificationService.GetUnreadNotificationCountByUsernameAsync(username);
            return Ok(new { count });
        }

        [HttpGet("user/{username}/unread/count")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> GetUnreadCountByUsername(string username)
        {
            var count = await _service.NotificationService.GetUnreadNotificationCountByUsernameAsync(username);
            return Ok(new { count });
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnreadNotifications()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            var notifications = await _service.NotificationService.GetUnreadNotificationsByUsernameAsync(username);
            return Ok(notifications);
        }

        [HttpGet("user/{username}/unread")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> GetUnreadNotificationsByUsername(string username)
        {
            var notifications = await _service.NotificationService.GetUnreadNotificationsByUsernameAsync(username);
            return Ok(notifications);
        }

        [HttpPost("send-by-username")]
        [ValidateCsrfToken]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> SendNotificationByUsername([FromBody] NotificationForCreationByUsernameDto dto)
        {
            var notification = await _service.NotificationService.SendNotificationByUsernameAsync(
                dto.Username,
                dto.Title,
                dto.Message,
                dto.Type,
                dto.Data
            );
            return Ok(new { message = "Notification sent successfully", notification });
        }

        [HttpPost("send-bulk-by-usernames")]
        [ValidateCsrfToken]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> SendBulkNotificationByUsernames([FromBody] SendBulkNotificationByUsernamesRequest request)
        {
            await _service.NotificationService.SendBulkNotificationByUsernamesAsync(
                request.Usernames, 
                request.Title, 
                request.Message, 
                request.Type, 
                request.Data);
            return Ok(new { message = "Bulk notifications sent successfully" });
        }
    }
}
