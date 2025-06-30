using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Security.Claims;
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
        public async Task<IActionResult> GetUserPharmacies([FromQuery] EmployeesParameters employeesParameters)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var pagedResult = await _service.PharmacyEmployeeService.GetUserPharmaciesAsync(userId, employeesParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.pharmacies);
        }

        [HttpPost("SendRequest")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager", "PharmacyEmployee")]
        [PermissionAuthorize("SendEmployeeRequest")]
        [ValidateCsrfToken]
        public async Task<IActionResult> SendRequest([FromBody] PharmacyEmployeeRequestCreateDto requestDto)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.PharmacyEmployeeRequestService.SendRequestAsync(requestDto, currentUserId, trackChanges: false);
            return Ok("Request sent successfully.");
        }

        [HttpPut("{requestId}/approve")]
        public async Task<IActionResult> ApproveRequest(Guid requestId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.PharmacyEmployeeRequestService.ApproveRequestAsync(requestId,userId,trackChanges:true);
            return NoContent();
        }

        [HttpPut("{requestId}/reject")]
        public async Task<IActionResult> RejectRequest(Guid requestId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.PharmacyEmployeeRequestService.RejectRequestAsync(requestId,userId,trackChanges:true);
            return NoContent();
        }

        [HttpGet("myrequests")]
        public async Task<IActionResult> GetRequests([FromQuery] EmployeesRequestParameters pharmacyRequestParameters)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var (pharmacyEmployeeRequests, metaData) = await _service.PharmacyEmployeeRequestService.GetRequestsAsync(pharmacyRequestParameters,userId, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(pharmacyEmployeeRequests);
        }

        [HttpGet("{pharmacyId}/employees")]
        [PharmacyRoleAuthorize("PharmacyOwner","PharmacyManager")]
        [PermissionAuthorize("GetEmployeeByPharmacy")]
        public async Task<IActionResult> GetEmployeesByPharmacy(Guid pharmacyId)
        {
            var employees = await _service.PharmacyEmployeeService.GetEmployeesByPharmacyAsync(pharmacyId);
            return Ok(employees);
        }
        
        /*
        [HttpGet("employees/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            var employee = await _service.PharmacyEmployeeService.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpDelete("employees/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            await _service.PharmacyEmployeeService.DeleteEmployeeAsync(employeeId);
            return NoContent();
        }*/
    }
}