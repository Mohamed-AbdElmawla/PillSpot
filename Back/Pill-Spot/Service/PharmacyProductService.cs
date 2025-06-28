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
using System.Text.Json;

namespace Service
{
    internal sealed class PharmacyProductService : IPharmacyProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public PharmacyProductService(IRepositoryManager repository, IMapper mapper, INotificationService notificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationService = notificationService;
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

            // Notify users about new product availability
            await _notificationService.SendProductInfoNotificationForProduct(
                pharmacyProductEntity.ProductId,
                pharmacyProductEntity.PharmacyId,
                pharmacyProductEntity.Product.Name,
                "NewProduct",
                $"New product '{pharmacyProductEntity.Product.Name}' is now available at {pharmacyProductEntity.Pharmacy.Name} with {pharmacyProductEntity.Quantity} items in stock."
            );

            return _mapper.Map<PharmacyProductDto>(pharmacyProductEntity);
        }

        public async Task UpdatePharmacyProductAsync(Guid productId, Guid pharmacyId, PharmacyProductForUpdateDto pharmacyProductForUpdateDto, bool trackChanges)
        {
            await CheckIfPharmacyNotExist(pharmacyId, trackChanges);
            await CheckIfProductNotExist(productId, trackChanges);
            var pharmacyProduct = await _repository.PharmacyProductRepository.GetPharmacyProductAsync(productId, pharmacyId, trackChanges);

            if (pharmacyProduct == null)
                throw new PharmacyProductNotFoundException(productId, pharmacyId);

            // Store old values for comparison
            var oldQuantity = pharmacyProduct.Quantity;
            var oldIsAvailable = pharmacyProduct.IsAvailable;
            var oldMinimumStockThreshold = pharmacyProduct.MinimumStockThreshold;

            // Update the entity
            if (pharmacyProductForUpdateDto.Quantity.HasValue)
                pharmacyProduct.Quantity = pharmacyProductForUpdateDto.Quantity.Value;
            
            if (pharmacyProductForUpdateDto.IsAvailable.HasValue)
                pharmacyProduct.IsAvailable = pharmacyProductForUpdateDto.IsAvailable.Value;
            
            if (pharmacyProductForUpdateDto.MinimumStockThreshold.HasValue)
                pharmacyProduct.MinimumStockThreshold = pharmacyProductForUpdateDto.MinimumStockThreshold.Value;

            await _repository.SaveAsync();

            // Send notifications based on what changed
            await SendUpdateNotifications(pharmacyProduct, oldQuantity, oldIsAvailable, oldMinimumStockThreshold);
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

            // Notify users about product removal
            await _notificationService.SendProductInfoNotificationForProduct(
                pharmacyProduct.ProductId,
                pharmacyProduct.PharmacyId,
                pharmacyProduct.Product.Name,
                "ProductRemoved",
                $"Product '{pharmacyProduct.Product.Name}' is no longer available at {pharmacyProduct.Pharmacy.Name}."
            );
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

        private async Task SendUpdateNotifications(PharmacyProduct pharmacyProduct, int oldQuantity, bool oldIsAvailable, int oldMinimumStockThreshold)
        {
            // Customer-facing notifications (sent to users with preferences)
            await SendCustomerNotifications(pharmacyProduct, oldQuantity, oldIsAvailable);

            // Internal notifications (sent to pharmacy managers/owners)
            await SendInternalNotifications(pharmacyProduct, oldQuantity, oldIsAvailable, oldMinimumStockThreshold);
        }

        private async Task SendCustomerNotifications(PharmacyProduct pharmacyProduct, int oldQuantity, bool oldIsAvailable)
        {
            // New product availability - always notify customers
            if (pharmacyProduct.IsAvailable && !oldIsAvailable)
            {
                await _notificationService.SendProductInfoNotificationForProduct(
                    pharmacyProduct.ProductId,
                    pharmacyProduct.PharmacyId,
                    pharmacyProduct.Product.Name,
                    "ProductAvailable",
                    $"'{pharmacyProduct.Product.Name}' is now available again at {pharmacyProduct.Pharmacy.Name}"
                );
            }

            // Low stock alert - only notify if quantity is critically low
            if (pharmacyProduct.Quantity <= pharmacyProduct.MinimumStockThreshold && pharmacyProduct.Quantity < oldQuantity)
            {
                await _notificationService.SendProductInfoNotificationForProduct(
                    pharmacyProduct.ProductId,
                    pharmacyProduct.PharmacyId,
                    pharmacyProduct.Product.Name,
                    "LowStock",
                    $"Low stock alert: '{pharmacyProduct.Product.Name}' at {pharmacyProduct.Pharmacy.Name} has only {pharmacyProduct.Quantity} items remaining."
                );
            }

            // Product unavailability - notify customers
            if (!pharmacyProduct.IsAvailable && oldIsAvailable)
            {
                await _notificationService.SendProductInfoNotificationForProduct(
                    pharmacyProduct.ProductId,
                    pharmacyProduct.PharmacyId,
                    pharmacyProduct.Product.Name,
                    "ProductUnavailable",
                    $"'{pharmacyProduct.Product.Name}' is temporarily unavailable at {pharmacyProduct.Pharmacy.Name}"
                );
            }
        }

        private async Task SendInternalNotifications(PharmacyProduct pharmacyProduct, int oldQuantity, bool oldIsAvailable, int oldMinimumStockThreshold)
        {
            // Stock restocked - internal notification for managers
            if (pharmacyProduct.Quantity > oldQuantity)
            {
                await _notificationService.SendNotificationToPharmacyManagersAsync(
                    pharmacyProduct.PharmacyId,
                    "Stock Restocked",
                    $"Stock of '{pharmacyProduct.Product.Name}' has been restocked at {pharmacyProduct.Pharmacy.Name}. New quantity: {pharmacyProduct.Quantity}",
                    NotificationType.StockAlert,
                    JsonSerializer.Serialize(new { 
                        productId = pharmacyProduct.ProductId, 
                        productName = pharmacyProduct.Product.Name,
                        oldQuantity,
                        newQuantity = pharmacyProduct.Quantity,
                        pharmacyId = pharmacyProduct.PharmacyId,
                        pharmacyName = pharmacyProduct.Pharmacy.Name
                    })
                );
            }

            // Stock reduced - internal notification for managers
            if (pharmacyProduct.Quantity < oldQuantity)
            {
                await _notificationService.SendNotificationToPharmacyManagersAsync(
                    pharmacyProduct.PharmacyId,
                    "Stock Reduced",
                    $"Stock of '{pharmacyProduct.Product.Name}' has been reduced at {pharmacyProduct.Pharmacy.Name}. New quantity: {pharmacyProduct.Quantity}",
                    NotificationType.StockAlert,
                    JsonSerializer.Serialize(new { 
                        productId = pharmacyProduct.ProductId, 
                        productName = pharmacyProduct.Product.Name,
                        oldQuantity,
                        newQuantity = pharmacyProduct.Quantity,
                        pharmacyId = pharmacyProduct.PharmacyId,
                        pharmacyName = pharmacyProduct.Pharmacy.Name
                    })
                );
            }

            // Threshold updated - internal notification for managers
            if (pharmacyProduct.MinimumStockThreshold != oldMinimumStockThreshold)
            {
                await _notificationService.SendNotificationToPharmacyManagersAsync(
                    pharmacyProduct.PharmacyId,
                    "Stock Threshold Updated",
                    $"Stock threshold for '{pharmacyProduct.Product.Name}' at {pharmacyProduct.Pharmacy.Name} has been updated from {oldMinimumStockThreshold} to {pharmacyProduct.MinimumStockThreshold}.",
                    NotificationType.StockAlert,
                    JsonSerializer.Serialize(new { 
                        productId = pharmacyProduct.ProductId, 
                        productName = pharmacyProduct.Product.Name,
                        oldThreshold = oldMinimumStockThreshold,
                        newThreshold = pharmacyProduct.MinimumStockThreshold,
                        pharmacyId = pharmacyProduct.PharmacyId,
                        pharmacyName = pharmacyProduct.Pharmacy.Name
                    })
                );
            }

            // Availability change - internal notification for managers
            if (pharmacyProduct.IsAvailable != oldIsAvailable)
            {
                var status = pharmacyProduct.IsAvailable ? "Available" : "Unavailable";
                await _notificationService.SendNotificationToPharmacyManagersAsync(
                    pharmacyProduct.PharmacyId,
                    $"Product {status}",
                    $"'{pharmacyProduct.Product.Name}' is now {status.ToLower()} at {pharmacyProduct.Pharmacy.Name}",
                    NotificationType.StockAlert,
                    JsonSerializer.Serialize(new { 
                        productId = pharmacyProduct.ProductId, 
                        productName = pharmacyProduct.Product.Name,
                        isAvailable = pharmacyProduct.IsAvailable,
                        pharmacyId = pharmacyProduct.PharmacyId,
                        pharmacyName = pharmacyProduct.Pharmacy.Name
                    })
                );
            }
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