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
    public static class PharmacyRequestRepositoryExtensions
    {
        public static IQueryable<PharmacyRequest> Sort(this IQueryable<PharmacyRequest> PharmacyRequests, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return PharmacyRequests.OrderBy(u => u.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<PharmacyRequest>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return PharmacyRequests.OrderBy(u => u.Name);

            return PharmacyRequests.OrderBy(orderQuery);
        }
    }
}
