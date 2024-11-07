using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryPharmacyMedicineExtensions
    {
        public static IQueryable<PharmacyMedicine> Paging(this IQueryable<PharmacyMedicine> Medicines, int PageNumber, int PageSize)
        {
            return Medicines
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize);
        }
    }
}
