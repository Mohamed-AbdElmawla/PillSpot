using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;

namespace PillSpot.Middleware
{
    public class AutoTokenRefreshMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AutoTokenRefreshMiddleware> _logger;

        public AutoTokenRefreshMiddleware(RequestDelegate next, ILogger<AutoTokenRefreshMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IServiceManager serviceManager)
        {
            try
            {
                // Get access token from Authorization header
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                var accessToken = authHeader?.StartsWith("Bearer ") == true 
                    ? authHeader.Substring("Bearer ".Length).Trim() 
                    : null;

                // Get refresh token from HttpOnly cookie
                var refreshToken = context.Request.Cookies["refreshToken"];

                // Only proceed if we have both tokens
                if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();

                    try
                    {
                        // Parse the access token to check expiry
                        var jwt = tokenHandler.ReadJwtToken(accessToken);
                        var expiry = jwt.ValidTo;

                        // Check if token expires within the next 5 minutes
                        if (expiry <= DateTime.UtcNow.AddMinutes(5))
                        {
                            _logger.LogInformation("Access token expires soon, attempting automatic refresh");

                            // Create TokenDto for refresh
                            var tokenDto = new TokenDto(accessToken, refreshToken);
                            
                            // Attempt to refresh the token
                            var newTokenDto = await serviceManager.AuthenticationService.RefreshToken(tokenDto);

                            if (newTokenDto != null)
                            {
                                // Update the request Authorization header with new access token
                                context.Request.Headers["Authorization"] = $"Bearer {newTokenDto.AccessToken}";

                                // Set new access token in response header for frontend to update
                                context.Response.Headers.Add("X-New-Access-Token", newTokenDto.AccessToken);

                                // Update refresh token in HttpOnly cookie
                                var cookieOptions = new CookieOptions
                                {
                                    HttpOnly = true,
                                    Secure = true, // Use HTTPS in production
                                    SameSite = SameSiteMode.Strict,
                                    Expires = DateTime.UtcNow.AddDays(7),
                                    Path = "/"
                                };

                                context.Response.Cookies.Append("refreshToken", newTokenDto.RefreshToken, cookieOptions);

                                _logger.LogInformation("Token successfully refreshed automatically");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // If token parsing fails, let the request continue normally
                        // The authorization will fail naturally if the token is invalid
                        _logger.LogWarning($"Failed to parse or refresh token: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AutoTokenRefreshMiddleware");
                // Don't block the request, let it continue
            }

            await _next(context);
        }
    }
} 