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
        IEnumerable<PharmacyMedicine> GetMedicines(int pharmacyId, bool trackChanges);
        PharmacyMedicine GetMedicine(int pharmacyId, int medicineId, bool trackChanges);
        void CreatePharmacyMedicine(int pharmacyId, PharmacyMedicine pharmacyMedicine);
    }
}
