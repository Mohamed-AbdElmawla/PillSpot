using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IAntiforgery _antiforgery;
        
        public TokenController(IServiceManager service, IAntiforgery antiforgery)
        {
            _service = service;
            _antiforgery = antiforgery;
        }

        [HttpPost("refresh")]
        [ValidateCsrfToken]
        public async Task<IActionResult> Refresh()
        {
            var accessToken = Request.Cookies["accessToken"];
            var refreshToken = Request.Cookies["refreshToken"];
            
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("No tokens found in cookies");
            }

            var tokenDto = new TokenDto(accessToken, refreshToken);
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);
            
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

            // Update access token cookie
            var accessCookieOptions = new CookieOptions
            {
                HttpOnly = baseCookieOptions.HttpOnly,
                Secure = baseCookieOptions.Secure,
                SameSite = baseCookieOptions.SameSite,
                Path = baseCookieOptions.Path,
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
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", tokenDtoToReturn.RefreshToken, refreshCookieOptions);
            
            return Ok(new { Message = "Tokens refreshed successfully" });
        }

        [HttpGet("csrf")]
        [RateLimit("CsrfTokenPolicy")]
        public IActionResult GenerateCsrfToken()
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            
            return Ok(new { 
                CsrfToken = tokens.RequestToken,
                HeaderName = "X-Csrf-Token"
            });
        }
    }
}
