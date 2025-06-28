using System;

namespace Entities.Exceptions
{
    public class ProductNotificationPreferenceNotFoundException : NotFoundException
    {
        public ProductNotificationPreferenceNotFoundException(string userId, string productId)
            : base($"The notification preference for user {userId} and product {productId} doesn't exist in the database.")
        {
        }
    }
} 