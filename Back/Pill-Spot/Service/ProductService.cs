using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using static System.Net.Mime.MediaTypeNames;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public ProductService(IRepositoryManager repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<ProductDto> CreateProductAsync(ProductForCreationDto productForCreationDto, bool trackChanges)
        {
            var subCategory = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync(productForCreationDto.SubCategoryId, trackChanges);
            if (subCategory == null)
                throw new SubCategoryNotFoundException(productForCreationDto.SubCategoryId);
            var productEntity = _mapper.Map<Product>(productForCreationDto);
            _repository.ProductRepository.CreateProduct(productEntity);
            productEntity.ImageURL = await _fileService.AddProductImageIfNotNull(productForCreationDto.Image);
            await _repository.SaveAsync();
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task DeleteProductAsync(Guid productId, bool trackChanges)
        {
            var productEntity = await GetProductByIdAndCheckIfItExist(productId, trackChanges);

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
            var productEntity = await GetProductByIdAndCheckIfItExist(productId, trackChanges);

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
            var productEntity = await GetProductByIdAndCheckIfItExist(productId, trackChanges);
            _mapper.Map(productForUpdateDto, productEntity);
            if (productForUpdateDto.Image != null) 
                productEntity.ImageURL = await _fileService.AddProductImageIfNotNull(productForUpdateDto.Image);
            await _repository.SaveAsync();
        }
        
        private async Task<Product> GetProductByIdAndCheckIfItExist(Guid productId, bool trackChanges)
        {
            var productEntity = await _repository.ProductRepository.GetProductAsync(productId, trackChanges);
            if (productEntity == null)
                throw new ProductNotFoundException(productId);
            return productEntity;
        }
    }

}
