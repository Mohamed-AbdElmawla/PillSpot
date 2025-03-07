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
        Task<Medicine> GetMedicineAsync(Guid productId, bool trackChanges);
        void CreateMedicine(Medicine medicine);
        void DeleteMedicine(Medicine medicine);
    }
}
