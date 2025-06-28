namespace Entities.ConfigurationModels
{
    public class CookieSettings
    {
        public const string Section = "CookieSettings";
        public string Domain { get; set; } = string.Empty;
        public int ExpirationMinutes { get; set; } = 60;
    }
} 