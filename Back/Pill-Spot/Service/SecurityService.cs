using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class SecurityService : ISecurityService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<SecurityService> _logger;
        private readonly TimeSpan _rateLimitWindow = TimeSpan.FromMinutes(1);
        private readonly int _maxRequestsPerWindow = 100;

        public SecurityService(IMemoryCache cache, ILogger<SecurityService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<string> GenerateCsrfTokenAsync()
        {
            throw new NotImplementedException("CSRF tokens are now handled by ASP.NET Core's built-in anti-forgery");
        }

        public async Task<bool> ValidateCsrfTokenAsync(string tokenFromHeader, string tokenFromCookie)
        {
            throw new NotImplementedException("CSRF validation is now handled by ASP.NET Core's built-in anti-forgery");
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