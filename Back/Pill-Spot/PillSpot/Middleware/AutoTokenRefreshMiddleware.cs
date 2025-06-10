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
                // Get access token from cookie (not Authorization header)
                var accessToken = context.Request.Cookies["accessToken"];
                var refreshToken = context.Request.Cookies["refreshToken"];

                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Add access token to Authorization header for downstream middleware/controllers
                    context.Request.Headers["Authorization"] = $"Bearer {accessToken}";

                    // Only proceed with refresh logic if we also have refresh token
                    if (!string.IsNullOrEmpty(refreshToken))
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

                                    // Update BOTH cookies with new tokens
                                    var baseCookieOptions = new CookieOptions
                                    {
                                        HttpOnly = true,
                                        Secure = true, // Use HTTPS in production
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
                                    context.Response.Cookies.Append("accessToken", newTokenDto.AccessToken, accessCookieOptions);

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
                                    context.Response.Cookies.Append("refreshToken", newTokenDto.RefreshToken, refreshCookieOptions);

                                    _logger.LogInformation("Both tokens successfully refreshed automatically in cookies");
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