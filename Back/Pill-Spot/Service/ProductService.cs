using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductForCreationDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _repository.ProductRepository.CreateProduct(productEntity);
            await _repository.SaveAsync();
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task DeleteProduct(ulong productId, bool trackChanges)
        {
            var product = await _repository.ProductRepository.GetProductAsync(productId, trackChanges);
            if (product == null)
                throw new ProductNotFoundException(productId);

            _repository.ProductRepository.DeleteProduct(product);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await _repository.ProductRepository.GetAllProductsAsync(trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductAsync(ulong productId, bool trackChanges)
        {
            var product = await _repository.ProductRepository.GetProductAsync(productId, trackChanges);
            if (product == null)
                throw new ProductNotFoundException(productId);

            await _repository.ProductRepository.LoadIngredientsAsync(product);
            await _repository.ProductRepository.LoadProductPharmaciesAsync(product);

            return _mapper.Map<ProductDto>(product);
        }
    }

}
