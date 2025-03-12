using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/pharmacy-employees")]
    [ApiController]
    public class PharmacyEmployeeController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyEmployeeController(IServiceManager service) => _service = service;


        [HttpGet("pharmacies")]
        [Authorize]
        public async Task<IActionResult> GetUserPharmacies([FromQuery] EmployeesParameters employeesParameters)
        {

            var userName = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
                throw new UserNameBadRequestException();
            var pagedResult = await _service.PharmacyEmployeeService.GetUserPharmaciesAsync(userName, employeesParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacies);
        }

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
