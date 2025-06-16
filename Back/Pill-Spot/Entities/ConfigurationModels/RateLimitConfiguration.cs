namespace Entities.ConfigurationModels
{
    public class RateLimitConfiguration
    {
        public string Section { get; set; } = "RateLimiting";
        public int GeneralLimit { get; set; } = 100;
        public int AuthenticationLimit { get; set; } = 10;
        public int SearchLimit { get; set; } = 30;
        public int UploadLimit { get; set; } = 20;
        public int WindowMinutes { get; set; } = 1;
    }
} 