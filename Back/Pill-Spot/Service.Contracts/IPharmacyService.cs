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
        Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetAllPharmaciesAsync(PharmaciesParameters pharmaciesparameters, bool trackChanges);
        Task<PharmacyDto> GetPharmacyAsync(ulong pharmacyId, bool trackChanges);
        Task<PharmacyDto> CreatePharmacyAsync(PharmacyForCreationDto pharmacy);
        Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetByIdsAsync(IEnumerable<ulong> id, PharmaciesParameters pharmaciesparameters, bool trackChanges);
        Task<(IEnumerable<PharmacyDto> pharmacies, string ids)> CreatePharmacyCollectionAsync(IEnumerable<PharmacyForCreationDto> pharmacyCollection);
        Task DeletePharmacy(ulong pharmacyId, bool trackChanges);
        Task UpdatePharmacy(ulong pharmacyId, PharmacyForUpdateDto pharmacyForUpdate, bool trackChanges);

    }
}
