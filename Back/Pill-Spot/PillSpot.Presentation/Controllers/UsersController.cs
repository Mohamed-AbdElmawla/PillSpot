using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;
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
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _service.UserService.GetUserAsync(userName, trackChanges: false);
            return Ok(user);
        }

        [HttpDelete("{userName}")]
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            await _service.UserService.DeleteUserAsync(userName, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{userName}")]
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUser(string userName, [FromForm] UserForUpdateDto userForUpdateDto)
        {
            await _service.UserService.UpdateUserAsync(userName, userForUpdateDto, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{userName}/update-password")]
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePassword(string userName, [FromBody] PasswordUpdateDto passwordDto)
        {
            await _service.UserService.UpdatePasswordAsync(userName, passwordDto);
            return NoContent();
        }

        [HttpPut("{userName}/update-email")]
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEmail(string userName, [FromBody] EmailUpdateDto emailDto)
        {
            await _service.UserService.UpdateEmailAsync(userName, emailDto);
            return NoContent();
        }

        [HttpGet("{userName}/roles")]
        [Authorize]
        [ServiceFilter(typeof(UserAuthorizationFilter))]
        public async Task<IActionResult> GetUserRoles(string userName)
        {
            var roles = await _service.UserService.GetUserRolesAsync(userName);
            return Ok(roles);
        }
    }   
}