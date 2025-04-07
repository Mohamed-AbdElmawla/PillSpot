using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NotificationController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetUserNotifications([FromQuery] NotificationRequestParameters requestParameters)
        {

            var username = User.Identity?.Name;
            var user = await _service.UserService.GetUserByNameAndCheckIfItExist(username);
            var userId = user.Id;

            var pagedResult = await _service.NotificationService.GetUserNotificationsAsync(userId, requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.notifications);
        }

        [HttpGet("find/{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetNotification(Guid id)
        {
            var notification = await _service.NotificationService.GetNotificationByIdAsync(id, trackChanges: false);
            return Ok(notification);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationForCreationDto notificationDto)
        {
            var createdNotification = await _service.NotificationService.CreateNotificationAsync(notificationDto);
            return CreatedAtAction(nameof(GetNotification), new { id = createdNotification.Id }, createdNotification);
        }

        [HttpPatch("{id:Guid}/mark-as-read")]
        public async Task<IActionResult> MarkNotificationAsRead(Guid id)
        {
            await _service.NotificationService.MarkAsNotifiedAsync(id, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteNotification(Guid id)
        {
            await _service.NotificationService.DeleteNotificationAsync(id, trackChanges: true);
            return NoContent();
        }
    }
}
