using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);
        Task<ProductDto> GetProductAsync(Guid productId, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductForCreationDto product);
        Task DeleteProduct(Guid productId, bool trackChanges);
    }
}
