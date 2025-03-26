using Entities.Exceptions;
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
        [Authorize(Roles = "SuperAdmin,Admin,PharmacyOwner,PharmacyManager")]
        public async Task<IActionResult> GetUserPharmacies([FromQuery] EmployeesParameters employeesParameters)
        {
            var username = User.Identity?.Name;
            var user = await _service.UserService.GetUserByNameAndCheckIfItExist(username);
            var userId = user.Id;

            var pagedResult = await _service.PharmacyEmployeeService.GetUserPharmaciesAsync(userId, employeesParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.pharmacies);
        }

        [HttpPost("SendRequest")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "SuperAdmin,Admin,PharmacyOwner,PharmacyManager")]
        public async Task<IActionResult> SendRequest([FromBody] PharmacyEmployeeRequestCreateDto requestDto)
        {
            var username = User.Identity?.Name;
            var user = await _service.UserService.GetUserByNameAndCheckIfItExist(username);
            var userId = user.Id;
            await _service.PharmacyEmployeeRequestService.SendRequestAsync(requestDto,userId,trackChanges:false);
            return Ok("Request sent successfully.");
        }

        [HttpPut("{requestId}/approve")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> ApproveRequest(Guid requestId)
        {
            var username = User.Identity?.Name;
            var user = await _service.UserService.GetUserByNameAndCheckIfItExist(username);
            var userId = user.Id;
            await _service.PharmacyEmployeeRequestService.ApproveRequestAsync(requestId,userId,trackChanges:true);
            return NoContent();
        }

        [HttpPut("{requestId}/reject")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RejectRequest(Guid requestId)
        {
            var username = User.Identity?.Name;
            var user = await _service.UserService.GetUserByNameAndCheckIfItExist(username);
            var userId = user.Id;
            await _service.PharmacyEmployeeRequestService.RejectRequestAsync(requestId,userId,trackChanges:true);
            return NoContent();
        }






        [HttpGet("{pharmacyId}/employees")]
        public async Task<IActionResult> GetEmployeesByPharmacy(Guid pharmacyId)
        {
            var employees = await _service.PharmacyEmployeeService.GetEmployeesByPharmacyAsync(pharmacyId);
            return Ok(employees);
        }

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
        }
    }
}
