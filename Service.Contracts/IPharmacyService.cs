using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPharmacyService
    {
        IEnumerable<PharmacyDto> GetAllPharmacies(bool trackChanges);
        PharmacyDto GetPharmacy(int pharmacyId, bool trackChanges);
    }
}
