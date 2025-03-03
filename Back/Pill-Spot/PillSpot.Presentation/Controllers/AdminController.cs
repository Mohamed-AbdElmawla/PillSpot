using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminController(IServiceManager service) => _service = service;

        [HttpPost("bulk-user-management")]
        public async Task<IActionResult> BulkUserManagement([FromForm] BulkUserManagementDto dto)
        {
            await _service.AdminService.BulkManageUsersAsync(dto);
            return NoContent();
        }

        [HttpPost("assign-user-role")]
        public async Task<IActionResult> AssignUserRole([FromForm] AssignUserRoleDto dto)
        {
            await _service.AdminService.AssignUserRoleAsync(dto);
            return NoContent();
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] UserParameters userParameters)
        {
            var pagedResult = await _service.UserService.GetUsersAsync(userParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.users);
        }

        [HttpGet("users/{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _service.UserService.GetUserAsync(userName, trackChanges: false);
            return Ok(user);
        }

        [HttpPut("users/{userName}/role")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AssignRole(string userName, [FromBody] RoleUpdateDto roleUpdateDto)
        {
            await _service.UserService.AssignRoleAsync(userName, roleUpdateDto.Role);
            return NoContent();
        }

        [HttpPost("users/{userName}/lockout")]
        public async Task<IActionResult> LockoutUser(string userName, [FromQuery] int days = 30)
        {
            await _service.UserService.LockoutUserAsync(userName, days);
            return NoContent();
        }

        [HttpPost("users/{userName}/unlock")]
        public async Task<IActionResult> UnlockUser(string userName)
        {
            await _service.UserService.UnlockUserAsync(userName);
            return NoContent();
        }
    }
    //[HttpGet("export-user-data")]
    //public async Task<IActionResult> ExportUserData()
    //{
    //    var fileData = await _service.KhaledService.ExportUserDataAsync();
    //    return File(fileData, "text/csv", "users.csv");
    //}
}
