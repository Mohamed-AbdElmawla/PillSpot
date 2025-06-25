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
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class SuperAdminController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SuperAdminController(IServiceManager service) => _service = service;

        [HttpGet("system/get-logs")]
        [Authorize(Roles ="SuperAdmin,Admin")]
        [PermissionAuthorize("GetLogs")]
        public async Task<IActionResult> GetLogs()
        {
            //Log.Information("Hello in get logs api");
            var logs = await _service.SerilogService.GetLogsAsync();
            return Ok(logs);
        }

        [HttpGet("system/get-logs-by-day")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("GetLogsByDay")]
        public async Task<IActionResult> GetLogsByDay([FromQuery] DateTime date)
        {
            var logs = await _service.SerilogService.GetLogsByDayAsync(date);
            return Ok(logs);
        }

        [HttpDelete("system/delete-logs")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("DeleteTodayLogs")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeleteTodayLogs()
        {
            //Log.Information("Hello in delete log api");
            await _service.SerilogService.DeleteTodayLogsAsync();
            return Ok("All log files have been deleted.");
        }

        [HttpDelete("system/delete-logs-by-day")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("DeleteLogsByDay")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeleteLogsByDay([FromQuery] DateTime date)
        {
            //Log.Information("Hello in delete logs by day api");
            await _service.SerilogService.DeleteLogsByDayAsync(date);
            return Ok($"Logs for {date:yyyy-MM-dd} have been deleted.");
        }


        [HttpGet("permissions-management/get-all")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("GetAllPermissions")]
        public async Task<IActionResult> GetAllPermissions([FromQuery] PermissionParameters permissionParameters)
        {
            var pagedResult = await _service.PermissionService.GetAllPermissionsAsync(permissionParameters, trackChanges: false);
            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(pagedResult.metaData);
            return Ok(pagedResult.permissions);
        }

        [HttpGet("permissions-management/get-by-/{id:Guid}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("GetPermissionbyId")]
        public async Task<IActionResult> GetPermissionbyId(Guid id)
        {
            var permissions = await _service.PermissionService.GetPermissionByIdAsync(id, trackChanges: false);
            return Ok(permissions);
        }

        [HttpPost("permissions-management/create")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionDto permissionDto)
        {
            if (permissionDto == null)
                throw new PermissionBadRequestException();

            var createdPermission = await _service.PermissionService.CreatePermissionAsync(permissionDto);
            return CreatedAtAction(nameof(GetPermissionbyId), new { id = createdPermission.PermissionId }, createdPermission);
        }

        [HttpPost("permissions-management/create-collection")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreatePermissionCollection([FromBody] IEnumerable<CreatePermissionDto> permissions)
        {
            var (createdPermissions, ids) = await _service.PermissionService.CreatePermissionCollectionAsync(permissions);

            return Created();
        }

        [HttpPut("permissions-management/update/{id:Guid}")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> UpdatePermission(Guid id, [FromBody] UpdatePermissionDto permissionDto)
        {
            if (permissionDto == null)
                throw new PermissionBadRequestException();

            await _service.PermissionService.UpdatePermissionAsync(id, permissionDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("permissions-management/delete-permission/{id:Guid}")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeletePermission(Guid id)
        {
            await _service.PermissionService.DeletePermissionAsync(id, trackChanges: true);
            return NoContent();
        }
        

        [HttpPost("admin-permission/assign")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> AssignPermissionToAdmin([FromBody] AssignAdminPermissionDto assignAdminPermissionDto)
        {
            var result = await _service.AdminPermissionService.AssignPermissionToAdminAsync(assignAdminPermissionDto , trackChanges:false);
            return CreatedAtRoute("GetAdminPermissions", new { adminId = result.AdminId }, result);
        }

        [HttpPost("admin-permission/assign-multiple/{adminId}")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> AssignPermissionsToAdmin(string adminId, [FromBody] IEnumerable<Guid> permissionIds)
        {
            var result = await _service.AdminPermissionService.AssignPermissionsToAdminAsync(adminId, permissionIds);
            return CreatedAtRoute("GetAdminPermissions", new { adminId = adminId }, result);
        }

        [HttpGet("admin-permission/{adminId}", Name = "GetAdminPermissions")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetPermissionsFromAdmin(string adminId)
        {
            var result = await _service.AdminPermissionService.GetPermissionsToAdminAsync(adminId, trackChanges: false);
            return Ok(result);
        }

        [HttpDelete("admin-permission/remove/{adminId}/{permissionId:Guid}")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> RemovePermissionFromAdmin(string adminId, Guid permissionId)
        {
            await _service.AdminPermissionService.RemovePermissionFromAdminAsync(adminId, permissionId);
            return NoContent();
        }

        [HttpDelete("admin-permission/remove-multiple/{adminId}")]
        [Authorize(Roles = "SuperAdmin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> RemovePermissionsFromAdmin(string adminId, [FromBody] IEnumerable<Guid> permissionIds)
        {
            await _service.AdminPermissionService.RemovePermissionsFromAdminAsync(adminId, permissionIds);
            return NoContent();
        }
    }
}