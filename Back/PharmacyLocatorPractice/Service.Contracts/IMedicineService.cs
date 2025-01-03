using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMedicineService
    {
        Task<MedicineDto> CreateMedicineAsync(MedicineForCreationDto medicine);
        Task<MedicineDto> GetMedicineAsync(string medicineId, bool trackChanges);
        Task DeleteMedicine(string medicineId, bool trackChanges);
    }
}
