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
    public static class OrderRepositoryExtensions
    {
        public static IQueryable<Order> Sort(this IQueryable<Order> orders, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return orders.OrderBy(u => u.CreatedDate);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return orders.OrderBy(u => u.CreatedDate);

            return orders.OrderBy(orderQuery);
        }

    }
}
