using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extentions
{
    public static class CartItemRepositoryExtensions
    {
        public static IQueryable<CartItem> ApplyCartItemFilters(this IQueryable<CartItem> items, CartItemRequestParameters parameters)
        {
            return items
                .FilterByPharmacy(parameters.PharmacyId)
                .FilterByProduct(parameters.ProductId)
                .FilterByProductType(parameters.ProductType)
                .FilterByDateRange(parameters.AddedAfter, parameters.AddedBefore)
                .FilterByPriceRange(parameters.MinPrice, parameters.MaxPrice);
        }
        public static IQueryable<CartItem> FilterByPharmacy(this IQueryable<CartItem> items, Guid? pharmacyId)
        {
            return pharmacyId.HasValue ? items.Where(i => i.PharmacyId == pharmacyId.Value) : items;
        }

        public static IQueryable<CartItem> FilterByProduct(this IQueryable<CartItem> items, Guid? productId)
        {
            return productId.HasValue ? items.Where(i => i.ProductId == productId.Value) : items;
        }

        public static IQueryable<CartItem> FilterByProductType(this IQueryable<CartItem> items, string? productType)
        {
            if (string.IsNullOrWhiteSpace(productType))
                return items;

            return productType switch
            {
                "Medicine" => items.Where(i => i.PharmacyProduct.Product is Medicine),
                "Cosmetic" => items.Where(i => i.PharmacyProduct.Product is Cosmetic),
                _ => items
            };
        }

        public static IQueryable<CartItem> FilterByDateRange(
            this IQueryable<CartItem> items,
            DateTime? addedAfter,
            DateTime? addedBefore)
        {
            if (addedAfter.HasValue)
                items = items.Where(i => i.AddedAt >= addedAfter.Value);

            if (addedBefore.HasValue)
                items = items.Where(i => i.AddedAt <= addedBefore.Value);

            return items;
        }

        public static IQueryable<CartItem> FilterByPriceRange(this IQueryable<CartItem> items, double? minPrice, double? maxPrice)
        {
            if (minPrice.HasValue)
                items = items.Where(i => i.PharmacyProduct.Product.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                items = items.Where(i => i.PharmacyProduct.Product.Price <= maxPrice.Value);

            return items;
        }
    }
}
