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

    }
    //[HttpGet("export-user-data")]
    //public async Task<IActionResult> ExportUserData()
    //{
    //    var fileData = await _service.KhaledService.ExportUserDataAsync();
    //    return File(fileData, "text/csv", "users.csv");
    //}
}
