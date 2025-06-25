using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service) => _service = service;
        [HttpPost]
        [RateLimit("AuthenticationPolicy")]
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
        [RateLimit("AuthenticationPolicy")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ValidateCsrfToken] // CSRF protection required when using cookies for auth
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            SetBothTokensCookies(tokenDto.AccessToken, tokenDto.RefreshToken);

            return Ok(new { Message = "Login successful" });
        }
        
        private void SetBothTokensCookies(string accessToken, string refreshToken)
        {
            // Determine if we're in development or production
            var env = (IWebHostEnvironment)HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment));
            var isDevelopment = env != null && env.IsDevelopment();
            
            var baseCookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = !isDevelopment, // Only require HTTPS in production
                SameSite = SameSiteMode.Strict,
                Path = "/"
            };

            // Access token cookie (short-lived)
            var accessCookieOptions = new CookieOptions
            {
                HttpOnly = baseCookieOptions.HttpOnly,
                Secure = baseCookieOptions.Secure,
                SameSite = baseCookieOptions.SameSite,
                Path = baseCookieOptions.Path,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };
            Response.Cookies.Append("accessToken", accessToken, accessCookieOptions);

            // Refresh token cookie (long-lived)
            var refreshCookieOptions = new CookieOptions
            {
                HttpOnly = baseCookieOptions.HttpOnly,
                Secure = baseCookieOptions.Secure,
                SameSite = baseCookieOptions.SameSite,
                Path = baseCookieOptions.Path,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", refreshToken, refreshCookieOptions);
        }


        [HttpPost("logout")]
        [ValidateCsrfToken]
        public async Task<IActionResult> Logout()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                return Unauthorized();

            await _service.AuthenticationService.LogoutAsync(userName);

            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");

            return Ok(new { Message = "Logout successful" });
        }

    }
}
