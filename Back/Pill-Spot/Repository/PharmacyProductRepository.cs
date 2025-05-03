using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class PharmacyProductRepository : RepositoryBase<PharmacyProduct>, IPharmacyProductRepository
    {
        public PharmacyProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<PharmacyProduct>> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await FindAll(trackChanges)
                .Include(pp => pp.Product)
                .Include(pp => pp.Pharmacy)
                .Include(pp => pp.Product.SubCategory)
                .Include(pp => pp.Product.SubCategory.Category)
                .Include(pp => pp.Pharmacy.Location)
                .ApplyFilters(pharmacyProductParameters)
                .Skip((pharmacyProductParameters.PageNumber - 1) * pharmacyProductParameters.PageSize)
                .Take(pharmacyProductParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<PharmacyProduct>(pharmacyProducts, count, pharmacyProductParameters.PageNumber, pharmacyProductParameters.PageSize);
        }

        public async Task<PharmacyProduct> GetPharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges) =>
            await FindByCondition(pp => pp.ProductId.Equals(productId) && pp.PharmacyId.Equals(pharmacyId), trackChanges)
                .Include(pp => pp.Product)
                .Include(pp => pp.Pharmacy)
                .Include(pp => pp.Product.SubCategory)
                .Include(pp => pp.Product.SubCategory.Category)
                .Include(pp => pp.Pharmacy.Location)
                .SingleOrDefaultAsync();

        public void CreatePharmacyProduct(PharmacyProduct pharmacyProduct) => Create(pharmacyProduct);

        public void DeletePharmacyProduct(PharmacyProduct pharmacyProduct) => Delete(pharmacyProduct);

        public async Task<PagedList<PharmacyProduct>> GetPharmacyProductsByPharmacyIdAsync(Guid pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await FindByCondition(pp => pp.PharmacyId.Equals(pharmacyId), trackChanges)
                .Include(pp => pp.Product)
                .Include(pp => pp.Pharmacy)
                .Include(pp => pp.Product.SubCategory)
                .Include(pp => pp.Product.SubCategory.Category)
                .Include(pp => pp.Pharmacy.Location)
                .ApplyFilters(pharmacyProductParameters)
                .Skip((pharmacyProductParameters.PageNumber - 1) * pharmacyProductParameters.PageSize)
                .Take(pharmacyProductParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(pp => pp.PharmacyId.Equals(pharmacyId), trackChanges).CountAsync();

            return new PagedList<PharmacyProduct>(pharmacyProducts, count, pharmacyProductParameters.PageNumber, pharmacyProductParameters.PageSize);
        }

        public async Task<PagedList<PharmacyProduct>> GetPharmacyProductsByProductIdAsync(Guid productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await FindByCondition(pp => pp.ProductId.Equals(productId), trackChanges)
                .Include(pp => pp.Product)
                .Include(pp => pp.Pharmacy)
                .Include(pp => pp.Product.SubCategory)
                .Include(pp => pp.Product.SubCategory.Category)
                .Include(pp => pp.Pharmacy.Location)
                .ApplyFilters(pharmacyProductParameters)
                .Skip((pharmacyProductParameters.PageNumber - 1) * pharmacyProductParameters.PageSize)
                .Take(pharmacyProductParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(pp => pp.ProductId.Equals(productId), trackChanges).CountAsync();

            return new PagedList<PharmacyProduct>(pharmacyProducts, count, pharmacyProductParameters.PageNumber, pharmacyProductParameters.PageSize);
        }

        /*public async Task<Batch?> GetBatchForPharmacyProductAsync(Guid productId, Guid pharmacyId, bool trackChanges)
        {
            var pharmacyProduct = await FindByCondition(pp => pp.ProductId.Equals(productId) && pp.PharmacyId.Equals(pharmacyId), trackChanges)
                .Include(pp => pp.Batch)
                .SingleOrDefaultAsync();

            return pharmacyProduct?.Batch;
        }*/

    }
}