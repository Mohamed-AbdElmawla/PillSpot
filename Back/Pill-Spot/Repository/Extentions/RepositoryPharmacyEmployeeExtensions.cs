using Entities.Models;
using Repository.Utility;
using System.Linq.Dynamic.Core;


namespace Repository.Extentions
{
    public static class RepositoryPharmacyEmployeeExtensions
    {
        public static IQueryable<PharmacyEmployee> Sort(this IQueryable<PharmacyEmployee> employees, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return employees.OrderBy(u => u.User.FirstName).ThenBy(u => u.User.LastName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<PharmacyEmployee>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return employees.OrderBy(u => u.User.FirstName).ThenBy(u => u.User.LastName);

            return employees.OrderBy(orderQuery);
        }
    }
}

