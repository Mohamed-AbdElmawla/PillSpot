using Entities.Models;
using Repository.Utility;
using Shared.RequestFeatures;
using System.Linq.Dynamic.Core;

public static class RepositoryPrescriptionProductExtensions
{
    public static IQueryable<PrescriptionProduct> Filter(this IQueryable<PrescriptionProduct> prescriptionProducts, PrescriptionProductParameters parameters)
    {
        if (!string.IsNullOrEmpty(parameters.ProductName))
            prescriptionProducts = prescriptionProducts.Where(pp => pp.Product.Name.Contains(parameters.ProductName));
        if (parameters.MinQuantity.HasValue)
            prescriptionProducts = prescriptionProducts.Where(pp => pp.Quantity >= parameters.MinQuantity.Value);
        if (parameters.MaxQuantity.HasValue)
            prescriptionProducts = prescriptionProducts.Where(pp => pp.Quantity <= parameters.MaxQuantity.Value);
        if (parameters.CategoryId.HasValue)
            prescriptionProducts = prescriptionProducts.Where(pp => pp.Product.SubCategory.CategoryId == parameters.CategoryId.Value);

        return prescriptionProducts;
    }

    public static IQueryable<PrescriptionProduct> Sort(this IQueryable<PrescriptionProduct> prescriptionProducts, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return prescriptionProducts.OrderBy(pp => pp.Product.Name);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<PrescriptionProduct>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return prescriptionProducts.OrderBy(pp => pp.Product.Name);

        return prescriptionProducts.OrderBy(orderQuery);
    }
}