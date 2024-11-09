using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Claims;

namespace PharmacyLocator.Presentation.Controllers
{
    [ApiController]
    [Route("api/Users/{userId}/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrdersController(IServiceManager serviceManager)=>_serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetOrders(string userId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
                return Forbid("You are not authorized to access this resource.");

            var orders = await _serviceManager.OrderService.GetOrdersByUserIdAsync(userId, trackChanges: false);
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(string userId, string orderId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
                return Forbid("You are not authorized to access this resource.");

            var order = await _serviceManager.OrderService.GetOrderAsync(userId, orderId, trackChanges: false);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(string userId, [FromBody] OrderForCreationDto orderForCreationDto)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
                return Forbid("You are not authorized to access this resource.");

            var createdOrder = await _serviceManager.OrderService.CreateOrderAsync(orderForCreationDto, userId);
            return Ok(createdOrder);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(string userId, string orderId, [FromBody] OrderForCreationDto orderForCreationDto)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != currentUserId)
                return Forbid("You are not authorized to access this resource.");

            await _serviceManager.OrderService.UpdateOrderAsync(orderId, userId, orderForCreationDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(string userId, string orderId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != currentUserId)
                return Forbid("You are not authorized to access this resource.");

            await _serviceManager.OrderService.DeleteOrderAsync(orderId, userId, trackChanges: false);
            return NoContent();
        }
    }
}
