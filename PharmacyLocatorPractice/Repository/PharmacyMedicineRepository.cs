using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
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

        public async Task<PagedList<PharmacyMedicine>> GetMedicinesAsync(int pharmacyId, PharmacyMedicineParameters pharmacyMedicineParameters, bool trackChanges)
        {
            var Medicines = await FindByCondition(md => md.PharmacyId.Equals(pharmacyId), trackChanges).Paging(pharmacyMedicineParameters.PageNumber,pharmacyMedicineParameters.PageSize).ToListAsync();

            var count = await FindByCondition(m=>m.PharmacyId == pharmacyId,trackChanges).CountAsync();

            return new PagedList<PharmacyMedicine>(Medicines, count, pharmacyMedicineParameters.PageNumber, pharmacyMedicineParameters.PageSize);
        }
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
