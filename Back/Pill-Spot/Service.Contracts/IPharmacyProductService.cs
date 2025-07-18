﻿using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPharmacyProductService
    {
        Task<(IEnumerable<PharmacyProductWithDistanceDto> pharmacyProducts, MetaData metaData)> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<PharmacyProductDto> GetPharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges);
        Task<PharmacyProductDto> CreatePharmacyProductAsync(PharmacyProductForCreationDto pharmacyProduct, bool trackChanges);
        Task UpdatePharmacyProductAsync(Guid productId, Guid pharmacyId, PharmacyProductForUpdateDto pharmacyProductForUpdateDto, bool trackChanges);
        Task DeletePharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges);
        Task<(IEnumerable<PharmacyProductWithDistanceDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByPharmacyIdAsync(Guid pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        Task<(IEnumerable<PharmacyProductWithDistanceDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByProductIdAsync(Guid productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges);
        /*Task<BatchDto> GetBatchForPharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges);*/
    }
}