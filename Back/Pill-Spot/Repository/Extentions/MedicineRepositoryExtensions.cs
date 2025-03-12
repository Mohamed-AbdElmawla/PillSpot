using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Entities.Models;
using Repository.Utility;

namespace Repository.Extentions
{
    public static class MedicineRepositoryExtensions
    {
        public static IQueryable<Medicine> Sort(this IQueryable<Medicine> medicines, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return medicines.OrderBy(u => u.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return medicines.OrderBy(u => u.Name);

            return medicines.OrderBy(orderQuery);
        }

        public static IQueryable<Medicine> Search(this IQueryable<Medicine> medicines, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return medicines;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return medicines.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
