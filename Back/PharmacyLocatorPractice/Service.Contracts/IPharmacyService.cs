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
        Task<PharmacyDto> GetPharmacyAsync(string pharmacyId, bool trackChanges);
        Task<PharmacyDto> CreatePharmacyAsync(PharmacyForCreationDto pharmacy);
        Task<IEnumerable<PharmacyDto>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges);
        Task<(IEnumerable<PharmacyDto> pharmacies, string ids)> CreatePharmacyCollectionAsync(IEnumerable<PharmacyForCreationDto> pharmacyCollection);
        Task DeletePharmacy(string pharmacyId, bool trackChanges);
        Task UpdatePharmacy(string pharmacyId, PharmacyForUpdateDto pharmacyForUpdate, bool trackChanges);
    }
}
