using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _service;
        public OrderController(IServiceManager service) => _service = service;

        [HttpGet]
        [RateLimit("SearchPolicy")]
        public async Task<IActionResult> GetAllOrders([FromQuery] OrderRequestParameters orderParameters)
        {
            var pagedResult = await _service.OrderService.GetOrdersAsync(orderParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.orders);
        }

        [HttpGet("{id:Guid}")]
        [RateLimit("SearchPolicy")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _service.OrderService.GetOrderByIdAsync(id, trackChanges: false);
            return Ok(order);
        }

        [HttpGet("user/{userId}")]
        [RateLimit("SearchPolicy")]
        public async Task<IActionResult> GetOrdersByUserId(string userId, [FromQuery] OrderRequestParameters orderParameters)
        {
            var pagedResult = await _service.OrderService.GetOrdersByUserIdAsync(userId, orderParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.orders);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto orderDto)
        {
            var createdOrder = await _service.OrderService.CreateOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize]
        [ValidateCsrfToken]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            var result = await _service.OrderService.CancelOrderAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
