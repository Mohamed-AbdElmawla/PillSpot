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

            // Store BOTH tokens in HttpOnly cookies for maximum security
            SetBothTokensCookies(tokenDto.AccessToken, tokenDto.RefreshToken);

            // Don't return tokens - they're in secure cookies
            return Ok(new { Message = "Login successful" });
        }
        
        private void SetBothTokensCookies(string accessToken, string refreshToken)
        {
            var baseCookieOptions = new CookieOptions
            {
                HttpOnly = true, // Prevents JavaScript access (XSS protection)
                Secure = true, // HTTPS only in production
                SameSite = SameSiteMode.Strict, // CSRF protection
                Path = "/"
                // Domain omitted for environment flexibility
            };

            // Access token cookie (short-lived)
            var accessCookieOptions = new CookieOptions
            {
                HttpOnly = baseCookieOptions.HttpOnly,
                Secure = baseCookieOptions.Secure,
                SameSite = baseCookieOptions.SameSite,
                Path = baseCookieOptions.Path,
                Expires = DateTime.UtcNow.AddMinutes(30) // Access token lifetime
            };
            Response.Cookies.Append("accessToken", accessToken, accessCookieOptions);

            // Refresh token cookie (long-lived)
            var refreshCookieOptions = new CookieOptions
            {
                HttpOnly = baseCookieOptions.HttpOnly,
                Secure = baseCookieOptions.Secure,
                SameSite = baseCookieOptions.SameSite,
                Path = baseCookieOptions.Path,
                Expires = DateTime.UtcNow.AddDays(7) // Refresh token lifetime
            };
            Response.Cookies.Append("refreshToken", refreshToken, refreshCookieOptions);
        }


        [HttpPost("logout")]
        [ValidateCsrfToken] // CSRF protection for cookie-based auth
        public async Task<IActionResult> Logout()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                return Unauthorized();

            await _service.AuthenticationService.LogoutAsync(userName);

            // Clear both token cookies
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");

            return Ok(new { Message = "Logout successful" });
        }

    }
}
