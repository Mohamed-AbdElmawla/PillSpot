using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Security.Claims;

namespace PharmacyLocator.Presentation.Controllers
{
    [ApiController]
    [Route("api/Users/{userId}/[controller]")]
    [Authorize]
    public class DeliveryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DeliveryController(IServiceManager service) => _service = service;

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingDeliveries(string userId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
            {
                return Forbid("You are not authorized to access this resource.");
            }
            var deliveries = await _service.DeliveryService.GetPendingDeliveriesAsync(userId, trackChanges: false);
            return Ok(deliveries);
        }

        [HttpGet("ReadyToDeliver")]
        public async Task<IActionResult> GetReadyToDeliverOrders(string userId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
            {
                return Forbid("You are not authorized to access this resource.");
            }
            var deliveries = await _service.DeliveryService.GetReadyToDeliverOrdersAsync(userId, trackChanges: false);
            return Ok(deliveries);
        }

        [HttpPut("{orderId}/MarkReadyToDeliver")]
        public async Task<IActionResult> MarkOrderAsReadyToDeliver(string userId, string orderId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
            {
                return Forbid("You are not authorized to access this resource.");
            }
            var success = await _service.DeliveryService.MarkOrderAsReadyToDeliverAsync(userId, orderId);
            if (!success) return NotFound($"Order with ID {orderId} not found.");
            return NoContent();
        }

        [HttpPut("{orderId}/MarkDelivered")]
        public async Task<IActionResult> MarkOrderAsDelivered(string userId, string orderId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
            {
                return Forbid("You are not authorized to access this resource.");
            }
            var success = await _service.DeliveryService.MarkOrderAsDeliveredAsync(userId, orderId);

            if (!success)
                return NotFound($"Order with ID {orderId} not found.");

            return NoContent();
        }
    }
}
