﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;

        public ProductService(
            IRepositoryManager repository, 
            IMapper mapper,
            IFileService fileService,
            INotificationService notificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
            _notificationService = notificationService;
        }

        public async Task<ProductDto> CreateProductAsync(ProductForCreationDto productForCreationDto, bool trackChanges)
        {
            var subCategory = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync(productForCreationDto.SubCategoryId, trackChanges);
            if (subCategory == null)
                throw new SubCategoryNotFoundException(productForCreationDto.SubCategoryId);
            var productEntity = _mapper.Map<Product>(productForCreationDto);
            _repository.ProductRepository.CreateProduct(productEntity);
            productEntity.ImageURL = await _fileService.AddProductImageIfNotNull(productForCreationDto.Image);
            
            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { productId = productEntity.ProductId });
                
                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                await SendProductCreationNotificationAfterTransactionAsync(productEntity, notificationData);
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }

            return _mapper.Map<ProductDto>(productEntity);
        }
        
        private async Task SendProductCreationNotificationAfterTransactionAsync(Product productEntity, string notificationData)
        {
            try
            {
                // Notify admin users about new product by usernames
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "New Product Added",
                    $"A new product '{productEntity.Name}' has been added to the inventory.",
                    NotificationType.ProductInfo,
                    notificationData
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send product creation notification: {ex.Message}");
            }
        }

        public async Task DeleteProductAsync(Guid productId, bool trackChanges)
        {
            var productEntity = await GetProductByIdAndCheckIfExists(productId, trackChanges);

            _repository.ProductRepository.DeleteProduct(productEntity);
            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductRequestParameters productRequestParameters, bool trackChanges)
        {
            var productsWithMetaData = await _repository.ProductRepository.GetAllProductsAsync(productRequestParameters, trackChanges);

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);

            return (products: productsDto, metaData: productsWithMetaData.MetaData);
        }

        public async Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges)
        {
            var productEntity = await GetProductByIdAndCheckIfExists(productId, trackChanges);

            await _repository.ProductRepository.LoadIngredientsAsync(productEntity);
            await _repository.ProductRepository.LoadProductPharmaciesAsync(productEntity);

            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task UpdateProductAsync(Guid productId, ProductForUpdateDto productForUpdateDto, bool trackChanges)
        {
            if (productForUpdateDto.SubCategoryId.HasValue)
            {
                var subCategory = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync((Guid)productForUpdateDto.SubCategoryId, trackChanges);
                if (subCategory == null)
                    throw new SubCategoryNotFoundException((Guid)productForUpdateDto.SubCategoryId);
            }
            var productEntity = await GetProductByIdAndCheckIfExists(productId, trackChanges);
            _mapper.Map(productForUpdateDto, productEntity);
            if (productForUpdateDto.Image != null) 
                productEntity.ImageURL = await _fileService.AddProductImageIfNotNull(productForUpdateDto.Image);
            await _repository.SaveAsync();
        }

        public async Task UpdateProductStockAsync(Guid productId, int quantity)
        {
            var product = await GetProductByIdAndCheckIfExists(productId, trackChanges: true);
            product.StockQuantity = quantity;
            
            // Use transaction to ensure data consistency
            await _repository.BeginTransactionAsync();
            try
            {
                await _repository.SaveAsync();
                
                // Prepare notification data
                var notificationData = JsonSerializer.Serialize(new { productId = product.ProductId, stockQuantity = quantity });
                
                await _repository.CommitTransactionAsync();
                
                // Send notifications outside of the transaction to avoid DbContext conflicts
                if (quantity <= 10)
                {
                    await SendStockAlertNotificationAfterTransactionAsync(product, quantity, notificationData);
                }
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        
        private async Task SendStockAlertNotificationAfterTransactionAsync(Product product, int quantity, string notificationData)
        {
            try
            {
                // Notify admin users about stock update by usernames
                await _notificationService.SendNotificationToRolesAsync(
                    new[] { "Admin", "SuperAdmin" },
                    "Low Stock Alert",
                    $"Product '{product.Name}' is running low on stock. Only {quantity} items left.",
                    NotificationType.StockAlert,
                    notificationData
                );
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the main operation
                Console.WriteLine($"Failed to send stock alert notification: {ex.Message}");
            }
        }
        
        private async Task<Product> GetProductByIdAndCheckIfExists(Guid productId, bool trackChanges)
        {
            var productEntity = await _repository.ProductRepository.GetProductAsync(productId, trackChanges);
            if (productEntity == null)
                throw new ProductNotFoundException(productId);
            return productEntity;
        }
    }
}
