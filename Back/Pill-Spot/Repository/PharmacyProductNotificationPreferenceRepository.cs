using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace PillSpot.Repository
{
    public class PharmacyProductNotificationPreferenceRepository : RepositoryBase<PharmacyProductNotificationPreference>, IPharmacyProductNotificationPreferenceRepository
    {
        public PharmacyProductNotificationPreferenceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PharmacyProductNotificationPreference> GetUserProductPreferenceAsync(string userId, Guid productId, Guid? pharmacyId, bool trackChanges)
        {
            return await FindByCondition(p => p.UserId == userId && 
                                             p.ProductId == productId && 
                                             p.PharmacyId == pharmacyId, trackChanges)
                .Include(p => p.Pharmacy)
                .Include(p => p.Product)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PharmacyProductNotificationPreference>> GetUserPreferencesAsync(string userId, bool trackChanges)
        {
            return await FindByCondition(p => p.UserId == userId, trackChanges)
                .Include(p => p.Pharmacy)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<PharmacyProductNotificationPreference>> GetUserProductPreferencesAsync(string userId, Guid productId, bool trackChanges)
        {
            return await FindByCondition(p => p.UserId == userId && p.ProductId == productId, trackChanges)
                .Include(p => p.Pharmacy)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<PharmacyProductNotificationPreference>> GetPreferencesForNotificationTypeAsync(string notificationType, bool trackChanges)
        {
            return await FindByCondition(p => p.IsEnabled && ("," + p.NotificationTypes + ",").Contains("," + notificationType + ","), trackChanges)
                .Include(p => p.Pharmacy)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<PharmacyProductNotificationPreference>> GetActivePreferencesAsync(bool trackChanges)
        {
            return await FindByCondition(p => p.IsEnabled && p.NotificationTypes.Any(), trackChanges)
                .Include(p => p.Pharmacy)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<PharmacyProductNotificationPreference>> GetPreferencesForProductAndTypeAsync(Guid productId, string notificationType, bool trackChanges)
        {
            return await FindByCondition(p => p.ProductId == productId && 
                                             p.IsEnabled && 
                                             ("," + p.NotificationTypes + ",").Contains("," + notificationType + ","), trackChanges)
                .Include(p => p.Pharmacy)
                .Include(p => p.Product)
                .Include(p => p.User)
                .ToListAsync();
        }

        public void CreatePreference(PharmacyProductNotificationPreference preference)
        {
            Create(preference);
        }

        public void UpdatePreference(PharmacyProductNotificationPreference preference)
        {
            Update(preference);
        }

        public void DeletePreference(PharmacyProductNotificationPreference preference)
        {
            Delete(preference);
        }

        public async Task<bool> HasActivePreferenceAsync(string userId, Guid productId, Guid? pharmacyId, string notificationType)
        {
            // Check for specific pharmacy preference
            if (pharmacyId.HasValue)
            {
                var specificPreference = await GetUserProductPreferenceAsync(userId, productId, pharmacyId, false);
                if (specificPreference != null && specificPreference.IsEnabled && specificPreference.NotificationTypes.Contains(notificationType))
                    return true;
            }

            // Check for general pharmacy preference (any pharmacy)
            var generalPreference = await GetUserProductPreferenceAsync(userId, productId, null, false);
            return generalPreference != null && generalPreference.IsEnabled && generalPreference.NotificationTypes.Contains(notificationType);
        }

        public async Task UpdateLastNotifiedAtAsync(string userId, Guid productId, Guid? pharmacyId)
        {
            var preference = await GetUserProductPreferenceAsync(userId, productId, pharmacyId, true);
            if (preference != null)
            {
                preference.LastNotifiedAt = DateTime.UtcNow;
                Update(preference);
            }
        }
    }
} 