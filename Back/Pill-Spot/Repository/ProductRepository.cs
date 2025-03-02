using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Delete(product);

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Product> GetProductAsync(ulong productId, bool trackChanges) =>
            await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).SingleOrDefaultAsync();

        public async Task LoadIngredientsAsync(Product product)
        {
            await RepositoryContext.Entry(product).Collection(p => p.ProductIngredients).LoadAsync();
        }

        public async Task LoadProductPharmaciesAsync(Product product)
        {
            await RepositoryContext.Entry(product).Collection(p => p.ProductPharmacies).LoadAsync();
        }
    }
}
