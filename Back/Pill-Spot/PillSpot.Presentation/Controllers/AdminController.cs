using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AdminController(IServiceManager service) => _service = service;

        [HttpPost("bulk-user-management")]
        public async Task<IActionResult> BulkUserManagement([FromBody] BulkUserManagementDto dto)
        {
            var username = User.Identity.Name;
            var user = await _service.UserService.GetUserByNameAndCheckIfItExist(username);
            var currentUserId = user.Id;
            await _service.AdminService.BulkManageUsersAsync(dto, currentUserId,trackChanges: false);
            return NoContent();
        }

        [HttpPost("assign-user-role")]
        public async Task<IActionResult> AssignUserRole([FromBody] AssignUserRoleDto dto)
        {
            var username = User.Identity.Name;
            var user = await _service.UserService.GetUserByNameAndCheckIfItExist(username);
            var currentUserId = user.Id;
            await _service.AdminService.AssignUserRoleAsync(dto, currentUserId);
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
