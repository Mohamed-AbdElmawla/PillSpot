using Entities.Exceptions;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICityService
    {
        Task<(IEnumerable<CityDto> cities, MetaData metaData)> GetAllCitiesAsync(CityRequestParameters cityRequestParameters, bool trackChanges);
        Task<CityDto> GetCityByIdAsync(Guid cityId, bool trackChanges);
        Task<IEnumerable<CityDto>> GetCitiesByGovernmentIdAsync(Guid governmentId, CityRequestParameters cityRequestParameters, bool trackChanges);
        Task<Guid> CreateCityAsync(CityForCreationDto city, bool trackChanges);
        Task UpdateCityAsync(Guid cityId, CityForUpdateDto city, bool trackChanges);
        Task DeleteCityAsync(Guid cityId, bool trackChanges);
        
    }
}
