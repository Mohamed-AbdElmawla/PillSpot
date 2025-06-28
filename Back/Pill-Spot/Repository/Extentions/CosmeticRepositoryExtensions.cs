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
    public static class CosmeticRepositoryExtensions
    {
        public static IQueryable<Cosmetic> Sort(this IQueryable<Cosmetic> cosmetics, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return cosmetics.OrderBy(u => u.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return cosmetics.OrderBy(u => u.Name);

            return cosmetics.OrderBy(orderQuery);
        }
        public static IQueryable<Cosmetic> Search(this IQueryable<Cosmetic> cosmetics, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return cosmetics;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return cosmetics.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
