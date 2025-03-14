using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/pharmacy-employees")]
    [ApiController]
    [Authorize]
    public class PharmacyEmployeeController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyEmployeeController(IServiceManager service) => _service = service;


        [HttpGet("pharmacies")]
        [Authorize(Roles ="SuperAdmin,Admin,PharmacyOwner,PharmacyManager")]
        public async Task<IActionResult> GetUserPharmacies([FromQuery] EmployeesParameters employeesParameters)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
                throw new UserNameBadRequestException();
            
            var pagedResult = await _service.PharmacyEmployeeService.GetUserPharmaciesAsync(userName, employeesParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.pharmacies);
        }

        [HttpPost("SendRequest")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> SendRequest([FromBody] PharmacyEmployeeRequestCreateDto requestDto)
        {
            await _service.PharmacyEmployeeRequestService.SendRequestAsync(requestDto,trackChanges:true);
            return Ok("Request sent successfully.");
        }

        [HttpPut("{requestId}/approve")]
        [Authorize(Roles = "SuperAdmin,Admin,PharmacyOwner,PharmacyManager")]
        public async Task<IActionResult> ApproveRequest(Guid requestId)
        {
            await _service.PharmacyEmployeeRequestService.ApproveRequestAsync(requestId,trackChanges:true);
            return NoContent();
        }

        [HttpPut("{requestId}/reject")]
        [Authorize(Roles = "SuperAdmin,Admin,PharmacyOwner,PharmacyManager")]
        public async Task<IActionResult> RejectRequest(Guid requestId)
        {
            await _service.PharmacyEmployeeRequestService.RejectRequestAsync(requestId,trackChanges:true);
            return NoContent();
        }

    }
}
