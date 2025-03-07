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
        Task<CosmeticDto> GetCosmeticAsync(Guid productId, bool trackChanges);
        Task<CosmeticDto> CreateCosmeticAsync(CosmeticForCreationDto cosmetic);
        Task DeleteCosmetic(Guid productId, bool trackChanges);
    }
}
