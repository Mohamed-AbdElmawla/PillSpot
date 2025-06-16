using Shared.DataTransferObjects;

namespace PillSpot.Service.Contracts
{
    public interface IProductNotificationPreferenceService
    {
        Task<ProductNotificationPreferenceDto> GetUserProductPreferenceAsync(string userId, Guid productId);
        Task<IEnumerable<ProductNotificationPreferenceDto>> GetUserPreferencesAsync(string userId);
        Task<ProductNotificationPreferenceDto> CreatePreferenceAsync(string userId, Guid productId, ProductNotificationPreferenceForCreationDto preferenceDto);
        Task UpdatePreferenceAsync(string userId, Guid productId, ProductNotificationPreferenceForUpdateDto preferenceDto);
        Task DeletePreferenceAsync(string userId, Guid productId);
        Task<bool> ShouldNotifyUserAsync(string userId, Guid productId, string notificationType);
    }
} 