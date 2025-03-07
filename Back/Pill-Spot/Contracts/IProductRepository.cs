using Entities.Models;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetProductAsync(Guid productId, bool trackChanges);
        Task LoadProductPharmaciesAsync(Product product);
        Task LoadIngredientsAsync(Product product);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
