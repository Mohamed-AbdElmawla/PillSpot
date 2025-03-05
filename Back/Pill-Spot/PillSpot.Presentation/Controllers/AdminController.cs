using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdminController(IServiceManager service) => _service = service;

        [HttpPost("bulk-user-management")]
        public async Task<IActionResult> BulkUserManagement([FromBody] BulkUserManagementDto dto)
        {
            await _service.AdminService.BulkManageUsersAsync(dto);
            return NoContent();
        }

        [HttpPost("assign-user-role")]
        public async Task<IActionResult> AssignUserRole([FromBody] AssignUserRoleDto dto)
        {
            await _service.AdminService.AssignUserRoleAsync(dto);
            return NoContent();
        }

        //[HttpGet("export-user-data")]
        //public async Task<IActionResult> ExportUserData()
        //{
        //    var fileData = await _service.KhaledService.ExportUserDataAsync();
        //    return File(fileData, "text/csv", "users.csv");
        //}
    }
}
