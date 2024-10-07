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
        PharmacyDto CreatePharmacy(PharmacyForCreationDto pharmacy);
        IEnumerable<PharmacyDto> GetByIds(IEnumerable<int> ids, bool trackChanges);
        (IEnumerable<PharmacyDto> pharmacies, string ids) CreatePharmacyCollection(IEnumerable<PharmacyForCreationDto> pharmacyCollection);
    }
}
