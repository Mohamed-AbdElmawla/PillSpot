using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UsersController(IServiceManager service) => _service = service;

        [HttpGet("{userName}")]
        [TypeFilter(typeof(UserAuthorizationFilter), Arguments = new object[] { new string[] { "Admin" } })]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _service.UserService.GetUserAsync(userName, trackChanges: false);
            return Ok(user);
        }

        [HttpDelete("{userName}")]
        [Authorize]
        [TypeFilter(typeof(UserAuthorizationFilter), Arguments = new object[] { new string[] { "Admin" } })]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            await _service.UserService.DeleteUserAsync(userName, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{userName}")]
        [TypeFilter(typeof(UserAuthorizationFilter), Arguments = new object[] { new string[] { "Admin" } })]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUser(string userName, [FromBody] UserForUpdateDto userForUpdateDto)
        {
            await _service.UserService.UpdateUserAsync(userName, userForUpdateDto, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{userName}/password")]
        [TypeFilter(typeof(UserAuthorizationFilter), Arguments = new object[] { new string[] { "Admin" } })]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePassword(string userName, [FromBody] PasswordUpdateDto passwordDto)
        {
            await _service.UserService.UpdatePasswordAsync(userName, passwordDto);
            return NoContent();
        }

        [HttpPut("{userName}/email")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEmail(string userName, [FromBody] EmailUpdateDto emailDto)
        {
            await _service.UserService.UpdateEmailAsync(userName, emailDto);
            return NoContent();
        }

        [HttpPut("{userName}/role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(string userName, [FromBody] RoleUpdateDto roleUpdateDto)
        {
            await _service.UserService.AssignRoleAsync(userName, roleUpdateDto.Role);
            return NoContent();
        }

        [HttpPost("{userName}/lockout")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> LockoutUser(string userName, [FromQuery] int days = 30)
        {
            await _service.UserService.LockoutUserAsync(userName, days);
            return NoContent();
        }

        [HttpPost("{userName}/unlock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnlockUser(string userName)
        {
            await _service.UserService.UnlockUserAsync(userName);
            return NoContent();
        }

        [HttpGet("{userName}/roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserRoles(string userName)
        {
            var roles = await _service.UserService.GetUserRolesAsync(userName);
            return Ok(roles);
        }

        [HttpPost("send-email-confirmation/{userName}")]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmailConfirmation(string userName)
        {
            await _service.UserService.SendEmailConfirmationAsync(userName);
            return Ok(new { Message = "Email confirmation sent." });
        }

    }
}
