using Entities.Models;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPharmacyProductRepository
    {
        Task<PagedList<PharmacyProduct>> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<PharmacyProduct> GetPharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges);
        void CreatePharmacyProduct(PharmacyProduct pharmacyProduct);
        void DeletePharmacyProduct(PharmacyProduct pharmacyProduct);
        Task<PagedList<PharmacyProduct>> GetPharmacyProductsByPharmacyIdAsync(Guid pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<PagedList<PharmacyProduct>> GetPharmacyProductsByProductIdAsync(Guid productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        /*Task<Batch?> GetBatchForPharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges);*/
    }
}