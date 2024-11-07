using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryPharmaciesExtensions
    {
        public static IQueryable<Pharmacy> Paging(this IQueryable<Pharmacy> Pharmacies, int PageNumber, int PageSize)
        {
            return Pharmacies
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize);
        }
    }
}
