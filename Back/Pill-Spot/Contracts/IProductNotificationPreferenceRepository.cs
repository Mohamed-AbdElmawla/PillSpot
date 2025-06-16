using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PillSpot.Contracts
{
    public interface IProductNotificationPreferenceRepository
    {
        Task<ProductNotificationPreference> GetUserProductPreferenceAsync(string userId, Guid productId, bool trackChanges);
        Task<IEnumerable<ProductNotificationPreference>> GetUserPreferencesAsync(string userId, bool trackChanges);
        Task<IEnumerable<ProductNotificationPreference>> GetPreferencesForNotificationTypeAsync(string notificationType, bool trackChanges);
        Task<IEnumerable<ProductNotificationPreference>> GetActivePreferencesAsync(bool trackChanges);
        void CreatePreference(ProductNotificationPreference preference);
        void UpdatePreference(ProductNotificationPreference preference);
        void DeletePreference(ProductNotificationPreference preference);
        Task<bool> HasActivePreferenceAsync(string userId, Guid productId, string notificationType);
        Task UpdateLastNotifiedAtAsync(string userId, Guid productId);
    }
} 