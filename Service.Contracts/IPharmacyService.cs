using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPharmacyService
    {
        Task<IEnumerable<PharmacyDto>> GetAllPharmaciesAsync(bool trackChanges);
        Task<PharmacyDto> GetPharmacyAsync(int pharmacyId, bool trackChanges);
        Task<PharmacyDto> CreatePharmacyAsync(PharmacyForCreationDto pharmacy);
        Task<IEnumerable<PharmacyDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        Task<(IEnumerable<PharmacyDto> pharmacies, string ids)> CreatePharmacyCollectionAsync(IEnumerable<PharmacyForCreationDto> pharmacyCollection);
    }
}
