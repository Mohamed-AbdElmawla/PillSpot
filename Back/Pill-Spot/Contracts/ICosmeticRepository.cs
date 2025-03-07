using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICosmeticRepository
    {
        Task<Cosmetic> GetCosmeticAsync(Guid productId, bool trackChanges);
        void CreateCosmetic(Cosmetic cosmetic);
        void DeleteCosmetic(Cosmetic cosmetic);
    }
}
