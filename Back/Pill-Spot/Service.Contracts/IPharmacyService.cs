using Entities.Exceptions;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPharmacyService
    {
        Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetAllPharmaciesAsync(PharmaciesParameters pharmaciesparameters, bool trackChanges);
        Task<PharmacyDto> GetPharmacyAsync(Guid pharmacyId, bool trackChanges);
        Task<PharmacyDto> CreatePharmacyAsync(PharmacyForCreationDto pharmacy);
        Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetByIdsAsync(IEnumerable<Guid> id, PharmaciesParameters pharmaciesparameters, bool trackChanges);
        Task<(IEnumerable<PharmacyDto> pharmacies, string ids)> CreatePharmacyCollectionAsync(IEnumerable<PharmacyForCreationDto> pharmacyCollection);
        Task DeletePharmacy(Guid pharmacyId, bool trackChanges);
        Task UpdatePharmacy(Guid pharmacyId, PharmacyForUpdateDto pharmacyForUpdate, bool trackChanges);
        Task SuspendPharmacyAsync(Guid pharmacyId, bool trackChanges);
        Task ActivatePharmacyAsync(Guid pharmacyId, bool trackChanges);
    }
}
