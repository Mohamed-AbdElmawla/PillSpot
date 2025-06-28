namespace Entities.ConfigurationModels
{
    public class CorsSettings
    {
        public const string Section = "CorsSettings";
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
    }
} 