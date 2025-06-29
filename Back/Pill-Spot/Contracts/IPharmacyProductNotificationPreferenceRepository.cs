using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPharmacyProductNotificationPreferenceRepository
    {
        Task<PharmacyProductNotificationPreference> GetUserProductPreferenceAsync(string userId, Guid productId, Guid? pharmacyId, bool trackChanges);
        Task<IEnumerable<PharmacyProductNotificationPreference>> GetUserPreferencesAsync(string userId, bool trackChanges);
        Task<IEnumerable<PharmacyProductNotificationPreference>> GetUserProductPreferencesAsync(string userId, Guid productId, bool trackChanges);
        Task<IEnumerable<PharmacyProductNotificationPreference>> GetPreferencesForNotificationTypeAsync(NotificationType notificationType, bool trackChanges);
        Task<IEnumerable<PharmacyProductNotificationPreference>> GetActivePreferencesAsync(bool trackChanges);
        Task<IEnumerable<PharmacyProductNotificationPreference>> GetPreferencesForProductAndTypeAsync(Guid productId, NotificationType notificationType, bool trackChanges);
        void CreatePreference(PharmacyProductNotificationPreference preference);
        void UpdatePreference(PharmacyProductNotificationPreference preference);
        void DeletePreference(PharmacyProductNotificationPreference preference);
        Task<bool> HasActivePreferenceAsync(string userId, Guid productId, Guid? pharmacyId, NotificationType notificationType);
        Task UpdateLastNotifiedAtAsync(string userId, Guid productId, Guid? pharmacyId);
    }
} 