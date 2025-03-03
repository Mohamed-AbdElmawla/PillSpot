using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPharmacyProductService
    {
        Task<(IEnumerable<PharmacyProductDto> pharmacyProducts, MetaData metaData)> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<PharmacyProductDto> GetPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges);
        Task<PharmacyProductDto> CreatePharmacyProductAsync(PharmacyProductForCreationDto pharmacyProduct);
        Task DeletePharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges);
        Task<(IEnumerable<PharmacyProductDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByPharmacyIdAsync(ulong pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<(IEnumerable<PharmacyProductDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByProductIdAsync(ulong productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<BatchDto> GetBatchForPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges);
    }
}