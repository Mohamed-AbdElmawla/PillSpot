using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service) => _service = service;
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromForm] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            SetTokenCookies(tokenDto.AccessToken, tokenDto.RefreshToken);

            return Ok(new { Message = "Login successful" });
        }
        private void SetTokenCookies(string accessToken, string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Ensure this is true in production
                SameSite = SameSiteMode.Strict, // or SameSiteMode.Lax
                Expires = DateTime.UtcNow.AddDays(7) // Set appropriate expiration
            };

            Response.Cookies.Append("AccessToken", accessToken, cookieOptions);
            Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userName = User.Identity?.Name;
            if (userName == null)
                return Unauthorized();

            await _service.AuthenticationService.LogoutAsync(userName);
            return NoContent();
        }

    }
}
