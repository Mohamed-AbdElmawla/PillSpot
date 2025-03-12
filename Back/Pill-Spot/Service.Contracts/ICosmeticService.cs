using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICosmeticService
    {
        Task<(IEnumerable<CosmeticDto> cosmetics, MetaData metaData)> GetAllCosmeticsAsync(CosmeticRequestParameters cosmeticRequestParameters, bool trackChanges);
        Task<CosmeticDto> GetCosmeticAsync(Guid productId, bool trackChanges);
        Task<CosmeticDto> CreateCosmeticAsync(CosmeticForCreationDto cosmeticForCreationDto, bool trackChanges);
        Task DeleteCosmeticAsync(Guid productId, bool trackChanges);
        Task UpdateCosmeticAsync(Guid productId, CosmeticForUpdateDto cosmeticForUpdateDto, bool trackChanges);
    }
}
