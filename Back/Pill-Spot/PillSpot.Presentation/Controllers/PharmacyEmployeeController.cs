using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PharmacyEmployeeController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyEmployeeController(IServiceManager service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> SendRequest([FromBody] PharmacyEmployeeRequestCreateDto requestDto)
        {
            await _service.PharmacyEmployeeRequestService.SendRequestAsync(requestDto);
            return Ok("Request sent successfully.");
        }

        [HttpPut("{requestId}/approve")]
        public async Task<IActionResult> ApproveRequest(Guid requestId)
        {
            await _service.PharmacyEmployeeRequestService.ApproveRequestAsync(requestId);
            return NoContent();
        }

        [HttpPut("{requestId}/reject")]
        public async Task<IActionResult> RejectRequest(Guid requestId)
        {
            await _service.PharmacyEmployeeRequestService.RejectRequestAsync(requestId);
            return NoContent();
        }

    }
}
