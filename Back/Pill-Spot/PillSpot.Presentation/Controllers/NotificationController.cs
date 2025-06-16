using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Service.Contracts.Notifications.Commands;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMediator _mediator;

        public NotificationController(INotificationService notificationService, IMediator mediator)
        {
            _notificationService = notificationService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserNotifications([FromQuery] NotificationRequestParameters parameters)
        {
            var userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var notifications = await _notificationService.GetUserNotificationsAsync(userId, parameters, false);
            return Ok(notifications);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id, false);
            return Ok(notification);
        }

        [HttpPost]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationCommand command)
        {
            var notificationDto = new NotificationForCreationDto
            {
                UserId = command.UserId,
                ActorId = command.ActorId ?? "system",
                Title = command.Title,
                Message = command.Message,
                Content = command.Message,
                Type = command.Type,
                Data = command.Data,
                RelatedEntityId = command.RelatedEntityId,
                RelatedEntityType = command.RelatedEntityType,
                IsBroadcast = command.IsBroadcast
            };

            var notification = await _notificationService.CreateNotificationAsync(notificationDto);
            return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationId }, notification);
        }

        [HttpDelete("{id:guid}")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeleteNotification(Guid id)
        {
            await _notificationService.DeleteNotificationAsync(id, false);
            return NoContent();
        }

        [HttpPost("{id:guid}/read")]
        [ValidateCsrfToken]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            await _notificationService.MarkNotificationAsReadAsync(id);
            return NoContent();
        }

        [HttpPost("read-all")]
        [ValidateCsrfToken]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _notificationService.MarkAllNotificationsAsReadAsync(userId);
            return NoContent();
        }

        [HttpGet("unread/count")]
        public async Task<IActionResult> GetUnreadCount()
        {
            var userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var count = await _notificationService.GetUnreadNotificationCountAsync(userId);
            return Ok(new { count });
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnreadNotifications()
        {
            var userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var notifications = await _notificationService.GetUnreadNotificationsAsync(userId);
            return Ok(notifications);
        }
    }
}
