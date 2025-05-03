using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using NetTopologySuite.Geometries;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<(IEnumerable<PharmacyProductWithDistanceDto> pharmacyProducts, MetaData metaData)> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await _repository.PharmacyProductRepository.GetAllPharmacyProductsAsync(pharmacyProductParameters, trackChanges);
            return CalculateDistancesAndMap(pharmacyProducts, pharmacyProductParameters);
        }

        public async Task<PharmacyProductDto> GetPharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges)
        {
            await CheckIfPharmacyNotExist(pharmacyId, trackChanges);
            await CheckIfProductNotExist(productId, trackChanges);
            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(productId, pharmacyId, trackChanges);

            if (pharmacyProduct == null)
                throw new PharmacyProductNotFoundException(productId, pharmacyId);

            return _mapper.Map<PharmacyProductDto>(pharmacyProduct);
        }

        public async Task<PharmacyProductDto> CreatePharmacyProductAsync(PharmacyProductForCreationDto pharmacyProductForCreationDto, bool trackChanges)
        {
            var pharmacy = await CheckIfPharmacyNotExist(pharmacyProductForCreationDto.PharmacyId, trackChanges);
            var product = await CheckIfProductNotExist(pharmacyProductForCreationDto.ProductId, trackChanges);
            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(pharmacyProductForCreationDto.ProductId, pharmacyProductForCreationDto.PharmacyId, trackChanges);

            if (pharmacyProduct != null)
                throw new PharmacyProductDuplicationBadRequestException(pharmacyProductForCreationDto.ProductId, pharmacyProductForCreationDto.PharmacyId);

            var pharmacyProductEntity = _mapper.Map<PharmacyProduct>(pharmacyProductForCreationDto);

            _repository.PharmacyProductRepository.CreatePharmacyProduct(pharmacyProductEntity);
            await _repository.SaveAsync();
            pharmacyProductEntity.Product = product;
            pharmacyProductEntity.Pharmacy = pharmacy;
            return _mapper.Map<PharmacyProductDto>(pharmacyProductEntity);
        }

        public async Task DeletePharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges)
        {
            await CheckIfPharmacyNotExist(pharmacyId, trackChanges);
            await CheckIfProductNotExist(productId, trackChanges);
            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(productId, pharmacyId, trackChanges);

            if (pharmacyProduct == null)
                throw new PharmacyProductNotFoundException(productId, pharmacyId);

            _repository.PharmacyProductRepository.DeletePharmacyProduct(pharmacyProduct);
            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<PharmacyProductWithDistanceDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByPharmacyIdAsync(Guid pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            await CheckIfPharmacyNotExist(pharmacyId, trackChanges);
            var pharmacyProducts = await _repository.PharmacyProductRepository.GetPharmacyProductsByPharmacyIdAsync(pharmacyId, pharmacyProductParameters, trackChanges);
            return CalculateDistancesAndMap(pharmacyProducts, pharmacyProductParameters);
        }

        public async Task<(IEnumerable<PharmacyProductWithDistanceDto> pharmacyProducts, MetaData metaData)> GetPharmacyProductsByProductIdAsync(Guid productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            await CheckIfProductNotExist(productId, trackChanges);
            var pharmacyProducts = await _repository.PharmacyProductRepository.GetPharmacyProductsByProductIdAsync(productId, pharmacyProductParameters, trackChanges);
            return CalculateDistancesAndMap(pharmacyProducts, pharmacyProductParameters);
        }

        private async Task<Pharmacy> CheckIfPharmacyNotExist(Guid pharmacyId, bool trackChanges)
        {
            var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(pharmacyId, trackChanges);
            if (pharmacy == null)
                throw new PharmacyNotFoundException(pharmacyId);
            return pharmacy;
        }

        private async Task<Product> CheckIfProductNotExist(Guid productId, bool trackChanges)
        {
            var product = await _repository.ProductRepository.GetProductAsync(productId, trackChanges);
            if (product == null)
                throw new ProductNotFoundException(productId);
            return product;
        }

        private (IEnumerable<PharmacyProductWithDistanceDto> pharmacyProducts, MetaData metaData) CalculateDistancesAndMap(PagedList<PharmacyProduct> pharmacyProducts, PharmacyProductParameters pharmacyProductParameters)
        {
            Point userPoint = null;
            if (pharmacyProductParameters.UserLatitude.HasValue && pharmacyProductParameters.UserLongitude.HasValue)
            {
                userPoint = new Point(pharmacyProductParameters.UserLongitude.Value, pharmacyProductParameters.UserLatitude.Value) { SRID = 4326 };
            }

            var pharmacyProductsWithDistance = pharmacyProducts.Select(pp =>
            {
                var pharmacyProductDto = _mapper.Map<PharmacyProductWithDistanceDto>(pp);

                if (userPoint != null)
                {
                    var pharmacyPoint = new Point(pp.Pharmacy.Location.Longitude, pp.Pharmacy.Location.Latitude) { SRID = 4326 };
                    pharmacyProductDto.Distance = pharmacyPoint.Distance(userPoint);
                }

                return pharmacyProductDto;
            });

            if (userPoint != null && pharmacyProductParameters.SortByDistanceAscending)
            {
                pharmacyProductsWithDistance = pharmacyProductsWithDistance.OrderBy(pp => pp.Distance);
            }
            else if (userPoint != null)
            {
                pharmacyProductsWithDistance = pharmacyProductsWithDistance.OrderByDescending(pp => pp.Distance);
            }

            return (pharmacyProductsWithDistance, pharmacyProducts.MetaData);
        }
    }
}