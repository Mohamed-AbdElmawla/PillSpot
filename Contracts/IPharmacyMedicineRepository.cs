using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPharmacyMedicineRepository
    {
        Task<IEnumerable<PharmacyMedicine>> GetMedicinesAsync(int pharmacyId, bool trackChanges);
        Task<PharmacyMedicine> GetMedicineAsync(int pharmacyId, int medicineId, bool trackChanges);
        void CreatePharmacyMedicine(int pharmacyId, PharmacyMedicine pharmacyMedicine);
        void DeletePharmacyMedicine(PharmacyMedicine pharmacyMedicine);
    }
}
