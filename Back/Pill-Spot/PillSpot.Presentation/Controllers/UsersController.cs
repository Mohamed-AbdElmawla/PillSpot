using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UsersController(IServiceManager service) => _service = service;

        [HttpGet("{userName}")]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _service.UserService.GetUserAsync(userName, trackChanges: false);
            return Ok(user);
        }

        [HttpPatch("{userName}")]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
     //   [PermissionAuthorize("UserManagement")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ValidateCsrfToken]
        public async Task<IActionResult> UpdateUser(string userName, [FromForm] UserForUpdateDto userForUpdateDto)
        {
            await _service.UserService.UpdateUserAsync(userName, userForUpdateDto, trackChanges: true);
            return NoContent();
        }


        [HttpPut("{userName}/update-password")]
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [PermissionAuthorize("UserManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> UpdatePassword(string userName, [FromBody] PasswordUpdateDto passwordDto)
        {
            await _service.UserService.UpdatePasswordAsync(userName, passwordDto);
            return NoContent();
        }


        [HttpPut("{userName}/update-email")]
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [PermissionAuthorize("UserManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> UpdateEmail(string userName, [FromBody] EmailUpdateDto emailDto)
        {
            await _service.UserService.UpdateEmailAsync(userName, emailDto);
            return NoContent();
        }


        [HttpGet("{userName}/roles")]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        [PermissionAuthorize("UserManagement")]
        public async Task<IActionResult> GetUserRoles(string userName)
        {
            var roles = await _service.UserService.GetUserRolesAsync(userName);
            return Ok(roles);
        }


        // admin
        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("UserManagement")]
        public async Task<IActionResult> GetUsers([FromQuery] UserParameters userParameters)
        {
            var pagedResult = await _service.UserService.GetUsersAsync(userParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.users);
        }


        [HttpPut("{userName}/role")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("UserManagement")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ValidateCsrfToken]
        public async Task<IActionResult> AssignRole(string userName, [FromBody] RoleUpdateDto roleUpdateDto)
        {
            await _service.UserService.AssignRoleAsync(userName, roleUpdateDto.Role);
            return NoContent();
        }

        [HttpPost("{userName}/lockout")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("UserManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> LockoutUser(string userName, [FromQuery] int days = 30)
        {
            await _service.UserService.LockoutUserAsync(userName, days);
            return NoContent();
        }

        [HttpPost("{userName}/unlock")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("UserManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> UnlockUser(string userName)
        {
            await _service.UserService.UnlockUserAsync(userName);
            return NoContent();
        }

        [HttpDelete("{userName}")]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            await _service.UserService.DeleteUserAsync(userName, trackChanges: true);
            return NoContent();
        }
    }   
}