using Entities.Models;
using Repository.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Extentions
{
    public static class UserRepositoryExtensions
    {
        public static IQueryable<User> Sort(this IQueryable<User> users, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return users.OrderBy(u => u.FirstName).ThenBy(u => u.LastName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<User>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return users.OrderBy(u => u.FirstName).ThenBy(u => u.LastName);

            return users.OrderBy(orderQuery);
        }
    }
}
