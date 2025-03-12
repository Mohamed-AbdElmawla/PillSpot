using Entities.Models;
using Repository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repository.Extentions
{
    public static class PharmacyProductRepositoryExtensions
    {
        public static IQueryable<PharmacyProduct> Sort(this IQueryable<PharmacyProduct> pharmacyProducts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return pharmacyProducts.OrderBy(u => u.Product.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<PharmacyProduct>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return pharmacyProducts.OrderBy(u => u.Product.Name);

            return pharmacyProducts.OrderBy(orderQuery);
        }
        public static IQueryable<PharmacyProduct> Search(this IQueryable<PharmacyProduct> pharmacyProducts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return pharmacyProducts;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return pharmacyProducts.Where(pp => pp.Product.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
