using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections.Generic;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OrdersController(IServiceManager service) => _service = service;

        
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _service.OrderService.GetOrdersAsync(trackChanges: false);
            return Ok(orders);
        }

        
        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _service.OrderService.GetOrderAsync(id, trackChanges: false);
            return Ok(order);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto orderDto)
        {
            if (orderDto is null)
                return BadRequest("OrderForCreationDto object is null");

            var orderToReturn = await _service.OrderService.CreateOrderAsync(orderDto, trackChanges: false);
            return CreatedAtRoute("GetOrder", new { id = orderToReturn.OrderId }, orderToReturn);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderForCreationDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("OrderForUpdateDto object is null");
            }

            await _service.OrderService.UpdateOrderAsync(id, orderDto, trackChanges: true);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _service.OrderService.DeleteOrderAsync(id, trackChanges: false);
            return NoContent();
        }

       // [HttpGet("status/{status}")]
        //public async Task<IActionResult> GetOrdersByStatusAsync(string status)
        //{
        //    var orders = await _service.OrderService.GetOrdersByStatusAsync(status, trackChanges: false);
        //    return Ok(orders);
        //}
    }
}
