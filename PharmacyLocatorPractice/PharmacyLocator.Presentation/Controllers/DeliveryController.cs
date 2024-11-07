using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DeliveryController(IServiceManager service) => _service = service;

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingDeliveries()
        {
            var deliveries = await _service.DeliveryService.GetPendingDeliveriesAsync(trackChanges: false);
            return Ok(deliveries);
        }
      
        [HttpGet("ReadyToDeliver")]
        public async Task<IActionResult> GetReadyToDeliverOrders()
        {
            var deliveries = await _service.DeliveryService.GetReadyToDeliverOrdersAsync(trackChanges: false);
            return Ok(deliveries);
        }

        [HttpPut("{orderId}/MarkReadyToDeliver")]
        public async Task<IActionResult> MarkOrderAsReadyToDeliver(int orderId)
        {
            var success = await _service.DeliveryService.MarkOrderAsReadyToDeliverAsync(orderId);
            if (!success) return NotFound($"Order with ID {orderId} not found.");
            return NoContent();
        }

        [HttpPut("{orderId}/mark-delivered")]
        public async Task<IActionResult> MarkOrderAsDelivered(int orderId)
        {
            var success = await _service.DeliveryService.MarkOrderAsDeliveredAsync(orderId);

            if (!success) 
                return NotFound($"Order with ID {orderId} not found.");

            return NoContent();
        }
    }
}
