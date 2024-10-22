using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMedicineRepository
    {
        Task<Medicine> GetMedicineAsync(int medicineId, bool trackChanges);
        void CreateMedicine(Medicine medicine);
    }
}
