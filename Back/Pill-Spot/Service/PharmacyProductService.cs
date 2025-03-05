using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PharmacyProductService : IPharmacyProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PharmacyProductService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<PharmacyProductDto> pharmacyProducts, MetaData metaData)> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await _repository.PharmacyProductRepository.GetAllPharmacyProductsAsync(pharmacyProductParameters, trackChanges);
            var pharmacyProductsDto = _mapper.Map<IEnumerable<PharmacyProductDto>>(pharmacyProducts);

            return (pharmacyProducts: pharmacyProductsDto, metaData: pharmacyProducts.MetaData);
        }

        public async Task<PharmacyProductDto> GetPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges)
        {
            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(productId, pharmacyId, trackChanges);

            if (pharmacyProduct == null)
                throw new PharmacyProductNotFoundException(productId, pharmacyId);

            return _mapper.Map<PharmacyProductDto>(pharmacyProduct);
        }

        public async Task<PharmacyProductDto> CreatePharmacyProductAsync(PharmacyProductForCreationDto pharmacyProduct)
        {
            var pharmacyProductEntity = _mapper.Map<PharmacyProduct>(pharmacyProduct);

            _repository.PharmacyProductRepository.CreatePharmacyProduct(pharmacyProductEntity);
            await _repository.SaveAsync();

            return _mapper.Map<PharmacyProductDto>(pharmacyProductEntity);
        }

        public async Task DeletePharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges)
        {
            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(productId, pharmacyId, trackChanges);

            if (pharmacyProduct == null)
                throw new PharmacyProductNotFoundException(productId, pharmacyId);

            _repository.PharmacyProductRepository.DeletePharmacyProduct(pharmacyProduct);
            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<PharmacyProductDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByPharmacyIdAsync(ulong pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await _repository.PharmacyProductRepository.GetPharmacyProductsByPharmacyIdAsync(pharmacyId, pharmacyProductParameters, trackChanges);
            var pharmacyProductsDto = _mapper.Map<IEnumerable<PharmacyProductDto>>(pharmacyProducts);

            return (pharmacyProducts: pharmacyProductsDto, metaData: pharmacyProducts.MetaData);
        }

        public async Task<(IEnumerable<PharmacyProductDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByProductIdAsync(ulong productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await _repository.PharmacyProductRepository.GetPharmacyProductsByProductIdAsync(productId, pharmacyProductParameters, trackChanges);
            var pharmacyProductsDto = _mapper.Map<IEnumerable<PharmacyProductDto>>(pharmacyProducts);

            return (pharmacyProducts: pharmacyProductsDto, metaData: pharmacyProducts.MetaData);
        }

        public async Task<BatchDto> GetBatchForPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges)
        {
            var batch = await _repository.PharmacyProductRepository.GetBatchForPharmacyProductAsync(productId, pharmacyId, trackChanges);

            if (batch == null)
                throw new BatchNotFoundException(productId, pharmacyId);

            return _mapper.Map<BatchDto>(batch);
        }
    }
}