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
        Task<MedicineDto> GetMedicineAsync(ulong productId, bool trackChanges);
        Task<MedicineDto> CreateMedicineAsync(MedicineForCreationDto medicine);
        Task DeleteMedicine(ulong productId, bool trackChanges);
    }
}
