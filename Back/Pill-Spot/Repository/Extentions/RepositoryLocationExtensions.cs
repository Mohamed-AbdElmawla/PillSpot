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
    public static class RepositoryLocationExtensions
    {
        public static IQueryable<Location> Sort(this IQueryable<Location> Locations, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return Locations.OrderBy(u => u.City.CityName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Location>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return Locations.OrderBy(u => u.City.CityName);

            return Locations.OrderBy(orderQuery);
        }
    }
}
