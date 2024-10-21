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
   public class PharmacyMedicineRepository: RepositoryBase<PharmacyMedicine>, IPharmacyMedicineRepository
    {
        public PharmacyMedicineRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<PharmacyMedicine>> GetMedicinesAsync(int pharmacyId, bool trackChanges) 
            => await FindByCondition(md=>md.PharmacyId.Equals(pharmacyId), trackChanges).ToListAsync();
        public async Task<PharmacyMedicine> GetMedicineAsync(int pharmacyId, int medicineId, bool trackChanges)
            =>await FindByCondition(md => md.PharmacyId.Equals(pharmacyId) && md.MedicineId.Equals(medicineId), trackChanges).SingleOrDefaultAsync();

        public void CreatePharmacyMedicine(int pharmacyId, PharmacyMedicine pharmacyMedicine)
        {
            pharmacyMedicine.PharmacyId = pharmacyId;
            Create(pharmacyMedicine);
        }
        public void DeletePharmacyMedicine(PharmacyMedicine pharmacyMedicine) => Delete(pharmacyMedicine);
    }
}
