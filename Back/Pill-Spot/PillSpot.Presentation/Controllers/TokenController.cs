using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service) => _service = service;

        [HttpPost("refresh")]
        [ValidateCsrfToken] // CSRF protection for cookie-based auth
        public async Task<IActionResult> Refresh()
        {
            // Get tokens from cookies instead of request body
            var accessToken = Request.Cookies["accessToken"];
            var refreshToken = Request.Cookies["refreshToken"];
            
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("No tokens found in cookies");
            }

            var tokenDto = new TokenDto(accessToken, refreshToken);
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);
            
            // Update BOTH token cookies
            var baseCookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Path = "/",
                Domain = "localhost"
            };

            // Update access token cookie
            var accessCookieOptions = new CookieOptions
            {
                HttpOnly = baseCookieOptions.HttpOnly,
                Secure = baseCookieOptions.Secure,
                SameSite = baseCookieOptions.SameSite,
                Path = baseCookieOptions.Path,
                Domain = baseCookieOptions.Domain,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };
            Response.Cookies.Append("accessToken", tokenDtoToReturn.AccessToken, accessCookieOptions);

            // Update refresh token cookie
            var refreshCookieOptions = new CookieOptions
            {
                HttpOnly = baseCookieOptions.HttpOnly,
                Secure = baseCookieOptions.Secure,
                SameSite = baseCookieOptions.SameSite,
                Path = baseCookieOptions.Path,
                Domain = baseCookieOptions.Domain,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", tokenDtoToReturn.RefreshToken, refreshCookieOptions);
            
            return Ok(new { Message = "Tokens refreshed successfully" });
        }
        [HttpGet("csrf")]
        public IActionResult GenerateCsrfToken()
        {
            var csrfToken = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false, // Allow JavaScript to read the token
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("CsrfToken", csrfToken, cookieOptions);
            return Ok(new { CsrfToken = csrfToken });
        }
    }
}
