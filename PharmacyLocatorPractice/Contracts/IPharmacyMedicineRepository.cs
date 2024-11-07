using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPharmacyMedicineRepository
    {
        Task<PagedList<PharmacyMedicine>> GetMedicinesAsync(int pharmacyId, PharmacyMedicineParameters pharmacyMedicineParameters, bool trackChanges);
        Task<PharmacyMedicine> GetMedicineAsync(int pharmacyId, int medicineId, bool trackChanges);
        void CreatePharmacyMedicine(int pharmacyId, PharmacyMedicine pharmacyMedicine);
        void DeletePharmacyMedicine(PharmacyMedicine pharmacyMedicine);
    }
}
