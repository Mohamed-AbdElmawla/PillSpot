using Microsoft.Extensions.Configuration;

namespace Service.Contracts
{
    public interface IConfigurationValidator
    {
        void ValidateConfiguration(IConfiguration configuration);
    }
} 