using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {

        }

        public async Task<Medicine> GetMedicineAsync(int medicineId, bool trackChanges) => await FindByCondition(md => md.Id.Equals(medicineId), trackChanges).SingleOrDefaultAsync();
    }
}
