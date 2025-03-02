using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetProductAsync(ulong productId, bool trackChanges);
        Task LoadProductPharmaciesAsync(Product product);
        Task LoadIngredientsAsync(Product product);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
