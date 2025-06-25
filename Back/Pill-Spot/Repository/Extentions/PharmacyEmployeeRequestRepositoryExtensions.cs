using Entities.Models;
using Repository.Utility;
using System.Linq.Dynamic.Core;


namespace Repository.Extentions
{
    public static class PharmacyEmployeeRequestRepositoryExtensions
    {
        public static IQueryable<PharmacyEmployeeRequest> Sort(this IQueryable<PharmacyEmployeeRequest> PharmacyEmployeeRequests, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return PharmacyEmployeeRequests.OrderBy(u => u.Status);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<PharmacyEmployeeRequest>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return PharmacyEmployeeRequests.OrderBy(u => u.Status);

            return PharmacyEmployeeRequests.OrderBy(orderQuery);
        }
    }
}