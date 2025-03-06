using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePermissionController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeePermissionController(IServiceManager service ) => _service = service;

        [HttpPost("assign")]
        public async Task<IActionResult> AssignPermissionToEmployee([FromBody] AssignEmployeePermissionDto assignEmployeePermissionDto)
        {
            var result = await _service.EmployeePermissionService.AssignPermissionToEmployeeAsync(assignEmployeePermissionDto);
            return CreatedAtRoute("GetEmployeePermissions", new { EmployeeID = result.EmployeeId }, result);
        }

        [HttpPost("assign-multiple/{employeeId}")]
        public async Task<IActionResult> AssignPermissionsToEmployee(ulong employeeId, [FromBody] IEnumerable<int> permissionIds)
        {
            var result = await _service.EmployeePermissionService.AssignPermissionsToEmployeeAsync(employeeId, permissionIds);
            return CreatedAtRoute("GetEmployeePermissions", new { EmployeeId = employeeId }, result);
        }

        [HttpGet("{employeeId}", Name = "GetEmployeePermissions")]
        public async Task<IActionResult> GetPermissionsToEmployee(ulong employeeId)
        {
            var result = await _service.EmployeePermissionService.GetPermissionsToEmployeeAsync(employeeId, trackChanges: false);
            return Ok(result);
        }

        [HttpDelete("remove/{employeeId}/{permissionId}")]
        public async Task<IActionResult> RemovePermissionFromEmployee(ulong employeeId, int permissionId)
        {
            await _service.EmployeePermissionService.RemovePermissionFromEmployeeAsync(employeeId, permissionId);
            return NoContent();
        }

        [HttpDelete("remove-multiple/{employeeId}")]
        public async Task<IActionResult> RemovePermissionsFromEmployee(ulong employeeId, [FromBody] IEnumerable<int> permissionIds)
        {
            await _service.EmployeePermissionService.RemovePermissionsFromEmployeeAsync(employeeId, permissionIds);
            return NoContent();
        }
    }
}
