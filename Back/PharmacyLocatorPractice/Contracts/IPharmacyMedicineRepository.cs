using Entities.Models;
using Shared.RequestFeatures;
namespace Contracts
{
    public interface IPharmacyMedicineRepository
    {
        Task<PagedList<PharmacyMedicine>> GetMedicinesAsync(string pharmacyId, PharmacyMedicineParameters pharmacyMedicineParameters, bool trackChanges);
        Task<PharmacyMedicine> GetMedicineAsync(string pharmacyId, string medicineId, bool trackChanges);
        void CreatePharmacyMedicine(string pharmacyId, PharmacyMedicine pharmacyMedicine);
        void DeletePharmacyMedicine(PharmacyMedicine pharmacyMedicine);
    }
}
