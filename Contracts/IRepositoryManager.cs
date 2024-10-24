using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IPharmacyMedicineRepository PharmacyMedicine { get; }
        IPharmacyRepository Pharmacy { get; }
        IMedicineRepository Medicine { get; }

        IOrderRepository Order { get; }

        Task SaveAsync();
    }
}
