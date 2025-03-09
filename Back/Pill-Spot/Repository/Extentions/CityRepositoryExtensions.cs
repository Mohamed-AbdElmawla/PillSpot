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
    public static class RepositoryCityExtensions
    {
        public static IQueryable<City> Sort(this IQueryable<City> cities, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return cities.OrderBy(u => u.CityName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<City>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return cities.OrderBy(u => u.CityName);

            return cities.OrderBy(orderQuery);
        }
    }
}
