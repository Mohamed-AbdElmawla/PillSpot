using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPharmacyMedicineService
    {
        Task<IEnumerable<PharmacyMedicineDto>> GetMedicinesAsync(int pharmacyId, bool trackChanges);
        Task<PharmacyMedicineDto> GetMedicineAsync(int pharmacyId, int medicineId, bool trackChanges);
        Task<PharmacyMedicineDto> CreatePharmacyMedicineAsync(int pharmacyId, PharmacyMedicineForCreationDto pharmacyMedicineCreationDto, bool trackChanges);
        Task DeletePharmacyMedicine(int pharmacyId, int pharmacyMedicineId, bool trackChanges);
        Task UpdatePharmacyMedicine(int pharmacyId, int medicineId, PharmacyMedicineForUpdateDto pharmacyMedicineForUpdate, bool phTrackChanges, bool phMedTrackChanges);
    }
}
