using PillSpot.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace PillSpot.Repository
{
    public class ProductNotificationPreferenceRepository : RepositoryBase<ProductNotificationPreference>, IProductNotificationPreferenceRepository
    {
        public ProductNotificationPreferenceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<ProductNotificationPreference> GetUserProductPreferenceAsync(string userId, Guid productId, bool trackChanges)
        {
            return await FindByCondition(p => p.UserId == userId && p.ProductId == productId.ToString(), trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductNotificationPreference>> GetUserPreferencesAsync(string userId, bool trackChanges)
        {
            return await FindByCondition(p => p.UserId == userId, trackChanges)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductNotificationPreference>> GetPreferencesForNotificationTypeAsync(string notificationType, bool trackChanges)
        {
            return await FindByCondition(p => p.IsEnabled && p.NotificationTypes.Contains(notificationType), trackChanges)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductNotificationPreference>> GetActivePreferencesAsync(bool trackChanges)
        {
            return await FindByCondition(p => p.IsEnabled && p.NotificationTypes.Any(), trackChanges)
                .ToListAsync();
        }

        public void CreatePreference(ProductNotificationPreference preference)
        {
            Create(preference);
        }

        public void UpdatePreference(ProductNotificationPreference preference)
        {
            Update(preference);
        }

        public void DeletePreference(ProductNotificationPreference preference)
        {
            Delete(preference);
        }

        public async Task<bool> HasActivePreferenceAsync(string userId, Guid productId, string notificationType)
        {
            var preference = await GetUserProductPreferenceAsync(userId, productId, false);
            return preference != null && preference.IsEnabled && preference.NotificationTypes.Contains(notificationType);
        }

        public async Task UpdateLastNotifiedAtAsync(string userId, Guid productId)
        {
            var preference = await GetUserProductPreferenceAsync(userId, productId, true);
            if (preference != null)
            {
                preference.LastNotifiedAt = DateTime.UtcNow;
                Update(preference);
            }
        }
    }
} 