using Entities.Models;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPharmacyProductRepository
    {
        Task<PagedList<PharmacyProduct>> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<PharmacyProduct> GetPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges);
        void CreatePharmacyProduct(PharmacyProduct pharmacyProduct);
        void DeletePharmacyProduct(PharmacyProduct pharmacyProduct);
        Task<PagedList<PharmacyProduct>> GetPharmacyProductsByPharmacyIdAsync(ulong pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<PagedList<PharmacyProduct>> GetPharmacyProductsByProductIdAsync(ulong productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<Batch> GetBatchForPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges);
    }
}