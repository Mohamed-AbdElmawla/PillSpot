using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class PharmacyMedicineRepository: RepositoryBase<PharmacyMedicine>, IPharmacyMedicineRepository
    {
        public PharmacyMedicineRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }

        public IEnumerable<PharmacyMedicine> GetMedicines(int pharmacyId, bool trackChanges) 
            => FindByCondition(md=>md.PharmacyId.Equals(pharmacyId), trackChanges).ToList();
        public PharmacyMedicine GetMedicine(int pharmacyId, int medicineId, bool trackChanges)
            =>FindByCondition(md => md.PharmacyId.Equals(pharmacyId) && md.MedicineId.Equals(medicineId), trackChanges).SingleOrDefault();
    }
}
