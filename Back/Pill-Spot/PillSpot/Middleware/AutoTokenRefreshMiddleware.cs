using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using Entities.ConfigurationModels;

namespace PillSpot.Middleware
{
    public class AutoTokenRefreshMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AutoTokenRefreshMiddleware> _logger;
        private readonly IConfiguration _configuration;

        public AutoTokenRefreshMiddleware(
            RequestDelegate next, 
            ILogger<AutoTokenRefreshMiddleware> logger,
            IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
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
                            var jwtToken = tokenHandler.ReadJwtToken(accessToken);
                            var expiry = jwtToken.ValidTo;

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
                                    var cookieSettings = _configuration.GetSection("CookieSettings").Get<CookieSettings>();
                                    if (cookieSettings == null)
                                    {
                                        throw new InvalidOperationException("Cookie settings are not configured");
                                    }

                                    var baseCookieOptions = new CookieOptions
                                    {
                                        HttpOnly = true,
                                        Secure = true,
                                        SameSite = SameSiteMode.Strict,
                                        Path = "/",
                                        Domain = cookieSettings.Domain,
                                        Expires = DateTime.UtcNow.AddMinutes(cookieSettings.ExpirationMinutes)
                                    };

                                    // Update access token cookie
                                    context.Response.Cookies.Append("accessToken", newTokenDto.AccessToken, baseCookieOptions);

                                    // Update refresh token cookie
                                    context.Response.Cookies.Append("refreshToken", newTokenDto.RefreshToken, baseCookieOptions);

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