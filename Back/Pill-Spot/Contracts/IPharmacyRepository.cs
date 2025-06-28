using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPharmacyRepository
    {
        Task<PagedList<Pharmacy>> GetAllPharmaciesAsync(PharmaciesParameters pharmaciesparameters, bool trackChanges);
        Task<Pharmacy> GetPharmacyAsync(Guid pharmacyId, bool trackChanges);
        void CreatePharmacy(Pharmacy pharmacy);
        Task<PagedList<Pharmacy>> GetByIdsAsync(IEnumerable<Guid> ids, PharmaciesParameters pharmaciesparameters, bool trackChanges);
        void DeletePharmacy(Pharmacy pharmacy);
    }
}
