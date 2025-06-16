using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Service
{
    public class SecurityService : ISecurityService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<SecurityService> _logger;
        private readonly TimeSpan _csrfTokenExpiration = TimeSpan.FromHours(1);
        private readonly TimeSpan _rateLimitWindow = TimeSpan.FromMinutes(1);
        private readonly int _maxRequestsPerWindow = 100;

        public SecurityService(IMemoryCache cache, ILogger<SecurityService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<string> GenerateCsrfTokenAsync()
        {
            // Generate a cryptographically secure random token
            var bytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            var token = Convert.ToBase64String(bytes);

            // Store the token in cache with expiration
            var cacheKey = $"csrf_token_{token}";
            _cache.Set(cacheKey, token, _csrfTokenExpiration);

            _logger.LogInformation("Generated new CSRF token");
            return token;
        }

        public async Task<bool> ValidateCsrfTokenAsync(string tokenFromHeader, string tokenFromCookie)
        {
            if (string.IsNullOrEmpty(tokenFromHeader) || string.IsNullOrEmpty(tokenFromCookie))
            {
                _logger.LogWarning("CSRF validation failed: Missing token in header or cookie");
                return false;
            }

            try
            {
                // URL decode both tokens for comparison
                var decodedHeaderToken = Uri.UnescapeDataString(tokenFromHeader);
                var decodedCookieToken = Uri.UnescapeDataString(tokenFromCookie);

                if (decodedHeaderToken != decodedCookieToken)
                {
                    _logger.LogWarning("CSRF validation failed: Token mismatch between header and cookie");
                    return false;
                }

                // Verify token exists in cache using the decoded token
                var cacheKey = $"csrf_token_{decodedHeaderToken}";
                var isValid = _cache.TryGetValue(cacheKey, out _);

                if (!isValid)
                {
                    _logger.LogWarning("CSRF validation failed: Token not found in cache or expired");
                }

                return isValid;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating CSRF token");
                return false;
            }
        }

        public async Task<bool> ShouldRateLimitAsync(string endpoint, string ipAddress)
        {
            var cacheKey = $"rate_limit_{endpoint}_{ipAddress}";
            
            if (!_cache.TryGetValue(cacheKey, out int requestCount))
            {
                requestCount = 0;
            }

            requestCount++;
            _cache.Set(cacheKey, requestCount, _rateLimitWindow);

            return requestCount > _maxRequestsPerWindow;
        }
    }
} 