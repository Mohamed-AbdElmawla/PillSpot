using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetAllProductsAsync(ProductRequestParameters productRequestParameters, bool trackChanges);
        Task<Product> GetProductAsync(Guid productId, bool trackChanges);
        Task LoadProductPharmaciesAsync(Product product);
        Task LoadIngredientsAsync(Product product);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}
