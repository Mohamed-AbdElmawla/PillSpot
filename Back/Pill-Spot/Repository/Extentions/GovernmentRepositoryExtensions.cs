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
    public static class GovernmentRepositoryExtensions
    {
        public static IQueryable<Government> Sort(this IQueryable<Government> governments, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return governments.OrderBy(u => u.GovernmentName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Government>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return governments.OrderBy(u => u.GovernmentName);

            return governments.OrderBy(orderQuery);
        }
    }
}
