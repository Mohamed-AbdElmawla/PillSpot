using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Entities.ConfigurationModels;

namespace Service
{
    public class ConfigurationValidator : IConfigurationValidator
    {
        public void ValidateConfiguration(IConfiguration configuration)
        {
            var requiredSettings = new Dictionary<string, string>
            {
                { "ConnectionStrings:MySqlConnection", "Database connection string" },
                { "JwtSettings:Secret", "JWT secret key" },
                { "JwtSettings:ValidIssuer", "JWT issuer" },
                { "JwtSettings:ValidAudience", "JWT audience" },
                { "CorsSettings:AllowedOrigins", "CORS allowed origins" },
                { "RateLimiting:GeneralLimit", "General rate limit" },
                { "RateLimiting:WindowMinutes", "Rate limit window" }
            };

            var missingSettings = new List<string>();

            foreach (var setting in requiredSettings)
            {
                if (string.IsNullOrEmpty(configuration[setting.Key]))
                {
                    missingSettings.Add($"{setting.Key} ({setting.Value})");
                }
            }

            if (missingSettings.Any())
            {
                throw new InvalidOperationException(
                    $"Missing required configuration settings:\n{string.Join("\n", missingSettings)}");
            }

            // Validate JWT settings
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtConfiguration>();
            if (jwtSettings == null)
            {
                throw new InvalidOperationException("JWT settings are not properly configured");
            }

            // Validate CORS settings
            var corsSettings = configuration.GetSection("CorsSettings").Get<CorsSettings>();
            if (corsSettings == null || !corsSettings.AllowedOrigins.Any())
            {
                throw new InvalidOperationException("CORS settings are not properly configured");
            }

            // Validate rate limiting settings
            var rateLimitSettings = configuration.GetSection("RateLimiting").Get<RateLimitConfiguration>();
            if (rateLimitSettings == null)
            {
                throw new InvalidOperationException("Rate limiting settings are not properly configured");
            }
        }
    }
} 