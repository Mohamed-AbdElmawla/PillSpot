using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMedicineRepository
    {
        Task<PagedList<Medicine>> GetAllMedicinesAsync(MedicinesRequestParameters medicinesRequestParameters, bool trackChanges);
        Task<Medicine> GetMedicineAsync(Guid productId, bool trackChanges);
        void CreateMedicine(Medicine medicine);
        void DeleteMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
    }
}
