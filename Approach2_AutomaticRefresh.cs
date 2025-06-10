using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PillSpot.Examples
{
    // Middleware for automatic token refresh
    public class AutoTokenRefreshMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthenticationService _authService;

        public AutoTokenRefreshMiddleware(RequestDelegate next, IAuthenticationService authService)
        {
            _next = next;
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var accessToken = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

            var refreshToken = context.Request.Cookies["refreshToken"] ?? 
                              context.Request.Headers["X-Refresh-Token"].FirstOrDefault();

            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                
                try
                {
                    var jwt = tokenHandler.ReadJwtToken(accessToken);
                    var expiry = jwt.ValidTo;

                    // Check if token expires within the next 5 minutes
                    if (expiry <= DateTime.UtcNow.AddMinutes(5))
                    {
                        var newToken = await _authService.RefreshTokenAsync(refreshToken);
                        
                        if (newToken.IsSuccess)
                        {
                            // Update the request header with new token
                            context.Request.Headers["Authorization"] = $"Bearer {newToken.AccessToken}";
                            
                            // Set new tokens in response headers/cookies
                            context.Response.Headers.Add("X-New-Access-Token", newToken.AccessToken);
                            context.Response.Headers.Add("X-New-Refresh-Token", newToken.RefreshToken);
                            
                            // Set HttpOnly cookie for refresh token
                            context.Response.Cookies.Append("refreshToken", newToken.RefreshToken, new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true,
                                SameSite = SameSiteMode.Strict,
                                Expires = DateTime.UtcNow.AddDays(7)
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    // Token is invalid, let it proceed and fail naturally
                }
            }

            await _next(context);
        }
    }

    // Enhanced controller for automatic refresh approach
    [ApiController]
    [Route("api/[controller]")]
    public class AuthControllerV2 : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthControllerV2(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            
            if (!result.IsSuccess)
                return Unauthorized();

            // Set refresh token as HttpOnly cookie
            Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            // Return only access token to frontend
            return Ok(new
            {
                AccessToken = result.AccessToken,
                AccessTokenExpiry = DateTime.UtcNow.AddMinutes(30),
                User = result.User
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            
            if (!string.IsNullOrEmpty(refreshToken))
            {
                await _authService.RevokeRefreshTokenAsync(refreshToken);
            }

            // Clear the refresh token cookie
            Response.Cookies.Delete("refreshToken");

            return Ok(new { message = "Logged out successfully" });
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _authService.GetUserByIdAsync(userId);
            
            return Ok(user);
        }
    }

    // Service registration extension
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAutoTokenRefresh(this IServiceCollection services)
        {
            services.AddScoped<AutoTokenRefreshMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseAutoTokenRefresh(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AutoTokenRefreshMiddleware>();
        }
    }

    // Program.cs configuration example
    /*
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddAutoTokenRefresh();
            
            var app = builder.Build();

            // Configure pipeline
            app.UseAuthentication();
            app.UseAutoTokenRefresh(); // Add this AFTER authentication
            app.UseAuthorization();
            
            app.MapControllers();
            app.Run();
        }
    }
    */
} 