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
        public IActionResult GetOrders()
        {
            var orders = _service.OrderService.GetOrders(trackChanges: false);
            return Ok(orders);
        }

        
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var order = _service.OrderService.GetOrder(id, trackChanges: false);
            return Ok(order);
        }


        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderForCreationDto orderDto)
        {
            if (orderDto is null)
                return BadRequest("OrderForCreationDto object is null");

            var orderToReturn = _service.OrderService.CreateOrder(orderDto, trackChanges: false);
            return CreatedAtRoute("GetOrder", new { id = orderToReturn.Id }, orderToReturn);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderForCreationDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("OrderForUpdateDto object is null");
            }

            _service.OrderService.UpdateOrder(id, orderDto, trackChanges: true);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _service.OrderService.DeleteOrder(id, trackChanges: false);
            return NoContent();
        }
    }
}
