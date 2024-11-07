using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPharmacyService
    {
        Task<(IEnumerable<PharmacyDto> Pharmacies, MetaData metaData)> GetAllPharmaciesAsync(bool trackChanges, PharmaciesParameters pharmaciesparameters);
        Task<PharmacyDto> GetPharmacyAsync(int pharmacyId, bool trackChanges);
        Task<PharmacyDto> CreatePharmacyAsync(PharmacyForCreationDto pharmacy);
        Task<IEnumerable<PharmacyDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        Task<(IEnumerable<PharmacyDto> pharmacies, string ids)> CreatePharmacyCollectionAsync(IEnumerable<PharmacyForCreationDto> pharmacyCollection);
        Task DeletePharmacy(int pharmacyId, bool trackChanges);
        Task UpdatePharmacy(int pharmacyId, PharmacyForUpdateDto pharmacyForUpdate, bool trackChanges);
    }
}
