using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Claims;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AdminController(IServiceManager service) => _service = service;

        [HttpPut("bulk-user-management")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles ="SuperAdmin,Admin")]
        [PermissionAuthorize("UserManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> BulkUserManagement([FromBody] BulkUserManagementDto dto)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.AdminService.BulkManageUsersAsync(dto, currentUserId,trackChanges: true);
            return NoContent();
        }

        [HttpPost("assign-user-role")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("AssignUserRole")]
        [ValidateCsrfToken]
        public async Task<IActionResult> AssignUserRole([FromBody] AssignUserRoleDto dto)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.AdminService.AssignUserRoleAsync(dto, currentUserId, trackChanges: true);
            return NoContent();
        }

        [HttpPost("pharmacy-employee/SendRequest")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [PharmacyRoleAuthorize("PharmacyOwner","PharmacyManager","PharmacyEmployee")]
        [PermissionAuthorize("SendEmployeeRequest")]
        [ValidateCsrfToken]
        public async Task<IActionResult> SendRequest([FromBody] PharmacyEmployeeRequestCreateDto requestDto)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.PharmacyEmployeeRequestService.SendRequestAsync(requestDto, currentUserId, trackChanges: false);
            return Ok("Request sent successfully.");
        }
    }
}