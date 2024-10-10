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
        IEnumerable<PharmacyMedicineDto> GetMedicines(int pharmacyId, bool trackChanges);
        PharmacyMedicineDto GetMedicine(int pharmacyId, int medicineId, bool trackChanges);
        PharmacyMedicineDto CreatePharmacyMedicine(int pharmacyId, PharmacyMedicineForCreationDto pharmacyMedicineCreationDto, bool trackChanges);
        void DeletePharmacyMedicine(int pharmacyId, int pharmacyMedicineId, bool trackChanges);
    }
}
