using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISecurityService
    {
        Task<string> GenerateCsrfTokenAsync();
        Task<bool> ValidateCsrfTokenAsync(string tokenFromHeader, string tokenFromCookie);
        Task<bool> ShouldRateLimitAsync(string endpoint, string ipAddress);
    }
} 