using Entities.Models;
using Repository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Shared.RequestFeatures;

namespace Repository.Extentions
{
    public static class PharmacyProductRepositoryExtensions
    {
        public static IQueryable<PharmacyProduct> ApplyFilters(this IQueryable<PharmacyProduct> pharmacyProducts,
           PharmacyProductParameters pharmacyProductParameters)
        {
            // Apply filters based on the parameters provided
            if (pharmacyProductParameters.SubCategoryId.HasValue)
                pharmacyProducts = pharmacyProducts.FilterBySubCategory(pharmacyProductParameters.SubCategoryId);

            if (pharmacyProductParameters.IsAvailable.HasValue)
                pharmacyProducts = pharmacyProducts.FilterByAvailability(pharmacyProductParameters.IsAvailable);

            if (pharmacyProductParameters.MinPrice.HasValue)
                pharmacyProducts = pharmacyProducts.FilterByMinPrice(pharmacyProductParameters.MinPrice);

            if (pharmacyProductParameters.MaxPrice.HasValue)
                pharmacyProducts = pharmacyProducts.FilterByMaxPrice(pharmacyProductParameters.MaxPrice);

            if (!string.IsNullOrWhiteSpace(pharmacyProductParameters.SearchTerm))
                pharmacyProducts = pharmacyProducts.Search(pharmacyProductParameters.SearchTerm);

            // Apply Distance filters if latitude and longitude are provided
            if (pharmacyProductParameters.UserLatitude.HasValue && pharmacyProductParameters.UserLongitude.HasValue)
            {
                pharmacyProducts = pharmacyProducts.ApplyDistanceFilter(
                    pharmacyProductParameters.UserLatitude.Value,
                    pharmacyProductParameters.UserLongitude.Value,
                    pharmacyProductParameters.MaxDistance);

                // Apply sorting based on distance if latitude and longitude are provided
                pharmacyProducts = pharmacyProducts.SortByDistance(
                    pharmacyProductParameters.UserLatitude.Value,
                    pharmacyProductParameters.UserLongitude.Value,
                    pharmacyProductParameters.SortByDistanceAscending);
            }

            // Apply sorting based on other criteria (if any)
            pharmacyProducts = pharmacyProducts.Sort(pharmacyProductParameters.OrderBy);

            return pharmacyProducts;
        }

        // Helper method to apply distance filter
        public static IQueryable<PharmacyProduct> ApplyDistanceFilter(this IQueryable<PharmacyProduct> pharmacyProducts,
            double userLatitude, double userLongitude, double? maxDistance)
        {
            // If maxDistance is not provided, skip the filtering
            if (!maxDistance.HasValue)
                return pharmacyProducts;

            return pharmacyProducts.Where(pp => DistanceUtility.CalculateDistance(
                pp.Pharmacy.Location.Latitude,
                pp.Pharmacy.Location.Longitude,
                userLatitude,
                userLongitude) <= maxDistance.Value);
        }

        // Helper method to sort products by distance
        public static IQueryable<PharmacyProduct> SortByDistance(this IQueryable<PharmacyProduct> pharmacyProducts,
            double? userLatitude, double? userLongitude, bool ascending = true)
        {
            // Skip sorting if latitude or longitude are not provided
            if (!userLatitude.HasValue || !userLongitude.HasValue)
                return pharmacyProducts;

            // Calculate distance and sort accordingly
            var sortedQuery = pharmacyProducts.Select(pp => new
            {
                PharmacyProduct = pp,
                Distance = DistanceUtility.CalculateDistance(
                    pp.Pharmacy.Location.Latitude,
                    pp.Pharmacy.Location.Longitude,
                    (double)userLatitude,
                    (double)userLongitude)
            });

            sortedQuery = ascending
                ? sortedQuery.OrderBy(x => x.Distance)
                : sortedQuery.OrderByDescending(x => x.Distance);

            return sortedQuery.Select(x => x.PharmacyProduct);
        }

        public static IQueryable<PharmacyProduct> FilterBySubCategory(this IQueryable<PharmacyProduct> pharmacyProducts, Guid? subCategoryId)
        {
            return subCategoryId.HasValue
                ? pharmacyProducts.Where(pp => pp.Product.SubCategoryId == subCategoryId.Value)
                : pharmacyProducts;
        }

        public static IQueryable<PharmacyProduct> FilterByAvailability(this IQueryable<PharmacyProduct> pharmacyProducts, bool? isAvailable)
        {
            return isAvailable.HasValue
                ? pharmacyProducts.Where(pp => (pp.Quantity > 0) == isAvailable.Value)
                : pharmacyProducts;
        }

        public static IQueryable<PharmacyProduct> FilterByMinPrice(this IQueryable<PharmacyProduct> pharmacyProducts, double? minPrice)
        {
            return minPrice.HasValue
                ? pharmacyProducts.Where(pp => pp.Product.Price >= minPrice.Value)
                : pharmacyProducts;
        }

        public static IQueryable<PharmacyProduct> FilterByMaxPrice(this IQueryable<PharmacyProduct> pharmacyProducts, double? maxPrice)
        {
            return maxPrice.HasValue
                ? pharmacyProducts.Where(pp => pp.Product.Price <= maxPrice.Value)
                : pharmacyProducts;
        }

        // Searching by product name
        public static IQueryable<PharmacyProduct> Search(this IQueryable<PharmacyProduct> pharmacyProducts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return pharmacyProducts;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return pharmacyProducts.Where(pp => pp.Product.Name.ToLower().Contains(lowerCaseTerm));
        }

        // Sorting method for other generic fields
        public static IQueryable<PharmacyProduct> Sort(this IQueryable<PharmacyProduct> pharmacyProducts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return pharmacyProducts.OrderBy(u => u.Product.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<PharmacyProduct>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return pharmacyProducts.OrderBy(u => u.Product.Name);

            return pharmacyProducts.OrderBy(orderQuery);
        }
    }
}
