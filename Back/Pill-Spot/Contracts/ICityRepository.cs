using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICityRepository
    {
        Task<PagedList<City>> GetAllCitiesAsync(CityRequestParameters cityRequestParameters, bool trackChanges);
        Task<City> GetCityByIdAsync(Guid cityId, bool trackChanges);
        Task<City> GetCityByNameAsync(string cityName, bool trackChanges);
        Task<PagedList<City>> GetCitiesByGovernmentIdAsync(Guid governmentId, CityRequestParameters cityRequestParameters, bool trackChanges);
        void CreateCity(City city);
        void DeleteCity(City city);
        void UpdateCity(City city);
    }
}
