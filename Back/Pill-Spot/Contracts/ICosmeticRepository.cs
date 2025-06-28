using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICosmeticRepository
    {
        Task<PagedList<Cosmetic>> GetAllCosmeticsAsync(CosmeticRequestParameters cosmeticRequestParameters, bool trackChanges);
        Task<Cosmetic> GetCosmeticAsync(Guid productId, bool trackChanges);
        void CreateCosmetic(Cosmetic cosmetic);
        void DeleteCosmetic(Cosmetic cosmetic);
        void UpdateCosmetic(Cosmetic cosmetic);
    }
}
