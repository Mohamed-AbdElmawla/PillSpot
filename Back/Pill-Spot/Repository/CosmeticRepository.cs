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
    internal sealed class CosmeticRepository : RepositoryBase<Cosmetic>, ICosmeticRepository
    {
        public CosmeticRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        
        public async Task<PagedList<Cosmetic>> GetAllCosmeticsAsync(CosmeticRequestParameters cosmeticRequestParameters, bool trackChanges)
        {
            var cosmetics = await FindAll(trackChanges)
                .Sort(cosmeticRequestParameters.OrderBy)
                .Search(cosmeticRequestParameters.SearchTerm)
                .Skip((cosmeticRequestParameters.PageNumber - 1) * cosmeticRequestParameters.PageSize)
                .Take(cosmeticRequestParameters.PageSize)
                .Include(p => p.SubCategory)
                    .ThenInclude(sc => sc.Category)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Cosmetic>(cosmetics, count, cosmeticRequestParameters.PageNumber, cosmeticRequestParameters.PageSize);
        }
        

        public void CreateCosmetic(Cosmetic cosmetic) => Create(cosmetic);

        public void DeleteCosmetic(Cosmetic cosmetic) => Delete(cosmetic);

        public void UpdateCosmetic(Cosmetic cosmetic) => Update(cosmetic);

        public async Task<Cosmetic> GetCosmeticAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(c => c.ProductId.Equals(productId), trackChanges)
                .Include(c => c.SubCategory)
                    .ThenInclude(sc => sc.Category)
                .SingleOrDefaultAsync();
    }
}
