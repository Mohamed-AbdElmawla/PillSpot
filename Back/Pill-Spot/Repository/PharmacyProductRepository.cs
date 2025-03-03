using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class PharmacyProductRepository : RepositoryBase<PharmacyProduct>, IPharmacyProductRepository
    {
        public PharmacyProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<PharmacyProduct>> GetAllPharmacyProductsAsync(PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await FindAll(trackChanges)
                .Include(pp => pp.Product)
                .Include(pp => pp.Pharmacy)
                .Include(pp => pp.Batch)
                .OrderBy(pp => pp.ProductId)
                .Skip((pharmacyProductParameters.PageNumber - 1) * pharmacyProductParameters.PageSize)
                .Take(pharmacyProductParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<PharmacyProduct>(pharmacyProducts, count, pharmacyProductParameters.PageNumber, pharmacyProductParameters.PageSize);
        }

        public async Task<PharmacyProduct> GetPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges) =>
            await FindByCondition(pp => pp.ProductId == productId && pp.PharmacyId == pharmacyId, trackChanges)
                .Include(pp => pp.Product)
                .Include(pp => pp.Pharmacy)
                .Include(pp => pp.Batch)
                .SingleOrDefaultAsync();

        public void CreatePharmacyProduct(PharmacyProduct pharmacyProduct) => Create(pharmacyProduct);

        public void DeletePharmacyProduct(PharmacyProduct pharmacyProduct) => Delete(pharmacyProduct);

        public async Task<PagedList<PharmacyProduct>> GetPharmacyProductsByPharmacyIdAsync(ulong pharmacyId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await FindByCondition(pp => pp.PharmacyId == pharmacyId, trackChanges)
                .Include(pp => pp.Product)
                .Include(pp => pp.Batch)
                .OrderBy(pp => pp.ProductId)
                .Skip((pharmacyProductParameters.PageNumber - 1) * pharmacyProductParameters.PageSize)
                .Take(pharmacyProductParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(pp => pp.PharmacyId == pharmacyId, trackChanges).CountAsync();

            return new PagedList<PharmacyProduct>(pharmacyProducts, count, pharmacyProductParameters.PageNumber, pharmacyProductParameters.PageSize);
        }

        public async Task<PagedList<PharmacyProduct>> GetPharmacyProductsByProductIdAsync(ulong productId, PharmacyProductParameters pharmacyProductParameters, bool trackChanges)
        {
            var pharmacyProducts = await FindByCondition(pp => pp.ProductId == productId, trackChanges)
                .Include(pp => pp.Pharmacy)
                .Include(pp => pp.Batch)
                .OrderBy(pp => pp.PharmacyId)
                .Skip((pharmacyProductParameters.PageNumber - 1) * pharmacyProductParameters.PageSize)
                .Take(pharmacyProductParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(pp => pp.ProductId == productId, trackChanges).CountAsync();

            return new PagedList<PharmacyProduct>(pharmacyProducts, count, pharmacyProductParameters.PageNumber, pharmacyProductParameters.PageSize);
        }

        public async Task<Batch> GetBatchForPharmacyProductAsync(ulong productId, ulong pharmacyId, bool trackChanges)
        {
            var pharmacyProduct = await FindByCondition(pp => pp.ProductId == productId && pp.PharmacyId == pharmacyId, trackChanges)
                .Include(pp => pp.Batch)
                .SingleOrDefaultAsync();

            return pharmacyProduct?.Batch;
        }

    }
}