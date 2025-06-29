using System;

namespace Entities.Exceptions
{
    public class PharmacyProductNotificationPreferenceNotFoundException : NotFoundException
    {
        public PharmacyProductNotificationPreferenceNotFoundException(string userId, Guid productId, Guid? pharmacyId)
            : base($"PharmacyProductNotificationPreference for UserId: {userId}, ProductId: {productId}, PharmacyId: {pharmacyId?.ToString() ?? "any"} was not found.")
        {
        }
    }
} 