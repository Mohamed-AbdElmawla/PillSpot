using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto> products, MetaData metaData)> GetAllProductsAsync(ProductRequestParameters productRequestParameters, bool trackChanges);
        Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductForCreationDto productForCreationDto, bool trackChanges);
        Task DeleteProductAsync(Guid productId, bool trackChanges);
        Task UpdateProductAsync(Guid productId, ProductForUpdateDto productForUpdateDto, bool trackChanges);
    }
}
