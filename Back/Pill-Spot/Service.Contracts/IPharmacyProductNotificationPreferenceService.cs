using Shared.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillSpot.Service.Contracts
{
    public interface IPharmacyProductNotificationPreferenceService
    {
        Task<PharmacyProductNotificationPreferenceDto> GetUserProductPreferenceAsync(string userId, Guid productId, Guid? pharmacyId);
        Task<IEnumerable<PharmacyProductNotificationPreferenceDto>> GetUserPreferencesAsync(string userId);
        Task<IEnumerable<PharmacyProductNotificationPreferenceDto>> GetUserProductPreferencesAsync(string userId, Guid productId);
        Task<PharmacyProductNotificationPreferenceDto> CreatePreferenceAsync(string userId, Guid productId, Guid? pharmacyId, PharmacyProductNotificationPreferenceForCreationDto preferenceDto);
        Task UpdatePreferenceAsync(string userId, Guid productId, Guid? pharmacyId, PharmacyProductNotificationPreferenceForUpdateDto preferenceDto);
        Task DeletePreferenceAsync(string userId, Guid productId, Guid? pharmacyId);
        Task<bool> ShouldNotifyUserAsync(string userId, Guid productId, Guid? pharmacyId, NotificationType notificationType);
        Task<IEnumerable<PharmacyProductNotificationPreferenceDto>> GetPreferencesForProductAndTypeAsync(Guid productId, NotificationType notificationType);
    }
} 