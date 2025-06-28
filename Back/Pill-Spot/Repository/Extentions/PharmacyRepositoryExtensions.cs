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
    public static class PharmacyRepositoryExtensions
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
        public static IQueryable<Pharmacy> Search(this IQueryable<Pharmacy> pharmacies, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return pharmacies;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return pharmacies.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
