using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPharmacyMedicineService
    {
        Task<(IEnumerable<PharmacyMedicineDto> Medicines, MetaData metaData)> GetMedicinesAsync(string pharmacyId, PharmacyMedicineParameters pharmacyMedicineParameters, bool trackChanges);
        Task<PharmacyMedicineDto> GetMedicineAsync(string pharmacyId, string medicineId, bool trackChanges);
        Task<PharmacyMedicineDto> CreatePharmacyMedicineAsync(string pharmacyId, PharmacyMedicineForCreationDto pharmacyMedicineCreationDto, bool trackChanges);
        Task DeletePharmacyMedicine(string pharmacyId, string pharmacyMedicineId, bool trackChanges);
        Task UpdatePharmacyMedicine(string pharmacyId, string medicineId, PharmacyMedicineForUpdateDto pharmacyMedicineForUpdate, bool phTrackChanges, bool phMedTrackChanges);
    }
}
