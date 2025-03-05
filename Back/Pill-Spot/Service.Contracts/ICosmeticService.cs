using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICosmeticService
    {
        Task<CosmeticDto> GetCosmeticAsync(ulong productId, bool trackChanges);
        Task<CosmeticDto> CreateCosmeticAsync(CosmeticForCreationDto cosmetic);
        Task DeleteCosmetic(ulong productId, bool trackChanges);
    }
}
