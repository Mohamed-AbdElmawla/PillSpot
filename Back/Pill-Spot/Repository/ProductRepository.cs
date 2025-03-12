using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
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

        public async Task<PagedList<Product>> GetAllProductsAsync(ProductRequestParameters productRequestParameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges)
                .Sort(productRequestParameters.OrderBy)
                .Skip((productRequestParameters.PageNumber - 1) * productRequestParameters.PageSize)
                .Take(productRequestParameters.PageSize)
                .Include(p => p.SubCategory)
                .ToListAsync();

                var count = await FindAll(trackChanges).CountAsync();

                return new PagedList<Product>(products, count, productRequestParameters.PageNumber, productRequestParameters.PageSize);
        }

        public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).Include(p => p.SubCategory).SingleOrDefaultAsync();

        public async Task LoadIngredientsAsync(Product product) => 
            await RepositoryContext.Entry(product).Collection(p => p.ProductIngredients).LoadAsync();

        public async Task LoadProductPharmaciesAsync(Product product) =>
            await RepositoryContext.Entry(product).Collection(p => p.PharmacyProducts).LoadAsync();

        public void DeleteProduct(Product product) => Delete(product);
        public void UpdateProduct(Product product) => Update(product);
    }
}
