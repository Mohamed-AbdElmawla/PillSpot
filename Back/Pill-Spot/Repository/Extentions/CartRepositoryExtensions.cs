using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extentions
{
    public static class CartRepositoryExtensions
    {
        public static IQueryable<Cart> ApplyCartFilters(this IQueryable<Cart> carts, CartRequestParameters parameters)
        {
            return carts
                .FilterByCartType(parameters.CartType)
                .FilterByUser(parameters.UserId)
                .FilterByCreationDate(parameters.CreatedAfter, parameters.CreatedBefore)
                .FilterByActivityStatus(parameters.IsActive)
                .FilterByItemCount(parameters.MinItems, parameters.MaxItems);
        }
        public static IQueryable<Cart> FilterByCartType(this IQueryable<Cart> carts, string? cartType)
        {
            return string.IsNullOrWhiteSpace(cartType) ? carts : carts.Where(c => c.CartType == cartType);
        }

        public static IQueryable<Cart> FilterByUser(this IQueryable<Cart> carts, string? userId)
        {
            return string.IsNullOrWhiteSpace(userId) ? carts : carts.Where(c => c.UserId == userId);
        }

        public static IQueryable<Cart> FilterByCreationDate(this IQueryable<Cart> carts, DateTime? createdAfter, DateTime? createdBefore)
        {
            if (createdAfter.HasValue)
                carts = carts.Where(c => c.CreatedAt >= createdAfter.Value);

            if (createdBefore.HasValue)
                carts = carts.Where(c => c.CreatedAt <= createdBefore.Value);

            return carts;
        }

        public static IQueryable<Cart> FilterByActivityStatus(this IQueryable<Cart> carts, bool? isActive)
        {
            return !isActive.HasValue ? carts : carts.Where(c => isActive.Value ? c.LastAccessed > DateTime.UtcNow.AddDays(-7) : c.LastAccessed <= DateTime.UtcNow.AddDays(-7));
        }

        public static IQueryable<Cart> FilterByItemCount(this IQueryable<Cart> carts, int? minItems, int? maxItems)
        {
            if (minItems.HasValue)
                carts = carts.Where(c => c.Items.Count >= minItems.Value);

            if (maxItems.HasValue)
                carts = carts.Where(c => c.Items.Count <= maxItems.Value);

            return carts;
        }
    }
}
