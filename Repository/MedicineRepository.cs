using Contracts;
using Entities.Models;
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

        public Medicine GetMedicine(int medicineId, bool trackChanges) => FindByCondition(md => md.Id.Equals(medicineId), trackChanges).SingleOrDefault();
    }
}
