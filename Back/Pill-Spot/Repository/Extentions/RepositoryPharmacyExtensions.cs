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
    public static class RepositoryPharmacyExtensions
    {
        public static IQueryable<Pharmacy> Sort(this IQueryable<Pharmacy> Pharmacies, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return Pharmacies.OrderBy(u => u.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Pharmacy>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return Pharmacies.OrderBy(u => u.Name);

            return Pharmacies.OrderBy(orderQuery);
        }
    }
}
