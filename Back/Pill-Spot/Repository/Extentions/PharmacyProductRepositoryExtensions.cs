using Entities.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Repository.Utility;
using Shared.RequestFeatures;
using System.Linq.Dynamic.Core;
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

        // Apply Distance filters if latitude and longitude are provided directly within the database
        if (pharmacyProductParameters.UserLatitude.HasValue && pharmacyProductParameters.UserLongitude.HasValue)
        {
            pharmacyProducts = pharmacyProducts.ApplyDatabaseDistanceFilter(
                pharmacyProductParameters.UserLatitude.Value,
                pharmacyProductParameters.UserLongitude.Value,
                pharmacyProductParameters.MaxDistance);
        }

        pharmacyProducts = pharmacyProducts.Sort(pharmacyProductParameters.OrderBy);

        return pharmacyProducts;
    }

    public static IQueryable<PharmacyProduct> ApplyDatabaseDistanceFilter(
    this IQueryable<PharmacyProduct> pharmacyProducts,
    double userLatitude,
    double userLongitude,
    double? maxDistance)
    {
        if (!maxDistance.HasValue) return pharmacyProducts;

        // Creating a point using a SQL function, as MySQL doesn't directly accept EF Core's geometry inputs
        return pharmacyProducts.Where(pp =>
            EF.Functions.Like(
                pp.Pharmacy.Location.Geography,
                $"ST_Distance_Sphere(pp.Pharmacy.Location.Geography, ST_GeomFromText('POINT({userLongitude} {userLatitude})', 4326)) <= {maxDistance.Value * 1000}"));
    }

    private static Point CreateGeographyPoint(double longitude, double latitude)
    {
        var geometryFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        return geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
    }

    // ... Other Helper Methods

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

    public static IQueryable<PharmacyProduct> Search(this IQueryable<PharmacyProduct> pharmacyProducts, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm)) return pharmacyProducts;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return pharmacyProducts.Where(pp => pp.Product.Name.ToLower().Contains(lowerCaseTerm));
    }

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