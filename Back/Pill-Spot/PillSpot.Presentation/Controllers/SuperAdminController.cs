using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SuperAdminController(IServiceManager service) => _service = service;

        [HttpGet("get-logs")]
        public async Task<IActionResult> GetLogs()
        {
            //Log.Information("Hello in get logs api");
            var logs = await _service.SerilogService.GetLogsAsync();
            return Ok(logs);
        }

        [HttpGet("get-logs-by-day")]
        public async Task<IActionResult> GetLogsByDay([FromQuery] DateTime date)
        {
            var logs = await _service.SerilogService.GetLogsByDayAsync(date);
            return Ok(logs);
        }

        [HttpDelete("delete-logs")]
        public async Task<IActionResult> DeleteTodayLogs()
        {
            //Log.Information("Hello in delete log api");
            await _service.SerilogService.DeleteTodayLogsAsync();
            return Ok("All log files have been deleted.");
        }

        [HttpDelete("delete-logs-by-day")]
        public async Task<IActionResult> DeleteLogsByDay([FromQuery] DateTime date)
        {
            //Log.Information("Hello in delete logs by day api");
            await _service.SerilogService.DeleteLogsByDayAsync(date);
            return Ok($"Logs for {date:yyyy-MM-dd} have been deleted.");
        }

//=====================================================================      PERMISSIONS      ========================================================================

        [HttpGet("get-all-permissions")]
        public async Task<IActionResult> GetAllPermissions([FromQuery]PermissionParameters permissionParameters)
        {
            var pagedResult = await _service.PermissionService.GetAllPermissionsAsync(permissionParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.permissions);
        }
        
        [HttpGet("get-permissions-by-/{id:int}")]
        public async Task<IActionResult> GetPermissionbyId(int id)
        {
            var permissions = await _service.PermissionService.GetPermissionByIdAsync(id,trackChanges: false);
            return Ok(permissions);
        }
        
        [HttpPost("create-permission")]
        public async Task<IActionResult> CreatePermission([FromForm] CreatePermissionDto permissionDto)
        {
            if (permissionDto == null)
                throw new PermissionBadRequestException();

            var createdPermission = await _service.PermissionService.CreatePermissionAsync(permissionDto);
            return CreatedAtAction(nameof(GetPermissionbyId),new {id=createdPermission.PermissionID},createdPermission);
        }
        
        [HttpPost("create-collection-permission")]
        public async Task<IActionResult> CreatePharmacyCollection([FromForm] IEnumerable<CreatePermissionDto> permissions)
        {
            var (createdPermissions, ids) = await _service.PermissionService.CreatePermissionCollectionAsync(permissions);

            return Created();
        }
        
        [HttpPut("update-permission/{id:int}")]
        public async Task<IActionResult> UpdatePermission(int id, [FromForm] UpdatePermissionDto permissionDto)
        {
            if (permissionDto == null)
                throw new PermissionBadRequestException();

            await _service.PermissionService.UpdatePermissionAsync(id, permissionDto, trackChanges: true);
            return NoContent();
        }
        
        [HttpDelete("delete-permission/{id:int}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            await _service.PermissionService.DeletePermissionAsync(id, trackChanges: true);
            return NoContent();
        }

        //=====================================================================      ADMIN      ========================================================================

        [HttpPost("assign")]
        public async Task<IActionResult> AssignPermissionToAdmin([FromForm] CreateAdminPermissionDto createAdminPermissionDto)
        {
            var result = await _service.AdminPermissionService.AssignPermissionToAdminAsync(createAdminPermissionDto);
            return CreatedAtRoute("GetAdminPermissions", new { adminId = result.AdminID }, result);
        }
        
        [HttpPost("assign-multiple/{adminId}")]
        public async Task<IActionResult> AssignPermissionsToAdmin(string adminId, [FromForm] IEnumerable<int> permissionIds)
        {
            var result = await _service.AdminPermissionService.AssignPermissionsToAdminAsync(adminId, permissionIds);
            return CreatedAtRoute("GetAdminPermissions", new { adminId = adminId }, result);
        }
        
        [HttpGet("{adminId}", Name = "GetAdminPermissions")]
        public async Task<IActionResult> GetPermissionsToAdmin(string adminId)
        {
            var result = await _service.AdminPermissionService.GetPermissionsToAdminAsync(adminId, trackChanges: false);
            return Ok(result);
        }
        
        [HttpDelete("remove/{adminId}/{permissionId}")]
        public async Task<IActionResult> RemovePermissionFromAdmin(string adminId, int permissionId)
        {
            await _service.AdminPermissionService.RemovePermissionFromAdminAsync(adminId, permissionId);
            return NoContent();
        }

        [HttpDelete("remove-multiple-from-employee/{adminId}")]
        public async Task<IActionResult> RemovePermissionsFromAdmin(string adminId, [FromForm] IEnumerable<int> permissionIds)
        {
            await _service.AdminPermissionService.RemovePermissionsFromAdminAsync(adminId, permissionIds);
            return NoContent();
        }

        //=====================================================================      EMPLOYEE      ========================================================================

        [HttpPost("assign-employee-permission")]
        public async Task<IActionResult> AssignPermissionToEmployee([FromForm] CreateEmployeePermissionDto createEmployeePermissionDto)
        {
            var result = await _service.EmployeePermissionService.AssignPermissionToEmployeeAsync(createEmployeePermissionDto);
            return CreatedAtRoute("GetEmployeePermissions", new { EmployeeID = result.EmployeeID }, result);
        }

        [HttpPost("assign-employee-multiple-permission/{employeeId}")]
        public async Task<IActionResult> AssignPermissionsToEmployee(ulong employeeId, [FromForm] IEnumerable<int> permissionIds)
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
        public async Task<IActionResult> RemovePermissionsFromEmployee(ulong employeeId, [FromForm] IEnumerable<int> permissionIds)
        {
            await _service.EmployeePermissionService.RemovePermissionsFromEmployeeAsync(employeeId, permissionIds);
            return NoContent();
        }


        //===============================================================================================================================================


    }
}