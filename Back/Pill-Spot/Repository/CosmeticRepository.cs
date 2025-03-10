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
    internal sealed class CosmeticRepository : RepositoryBase<Cosmetic>, ICosmeticRepository
    {
        public CosmeticRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateCosmetic(Cosmetic cosmetic) => Create(cosmetic);

        public void DeleteCosmetic(Cosmetic cosmetic) => Delete(cosmetic);

        public void UpdateCosmetic(Cosmetic cosmetic) => Update(cosmetic);

        public async Task<Cosmetic> GetCosmeticAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(c => c.ProductId.Equals(productId), trackChanges).Include(c => c.SubCategory).SingleOrDefaultAsync();
    }
}
