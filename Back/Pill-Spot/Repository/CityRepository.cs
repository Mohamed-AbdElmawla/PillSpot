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
    internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<City>> GetAllCitiesAsync(CityRequestParameters cityRequestParameters, bool trackChanges)
        {
            var cities = await FindAll(trackChanges)
                .Sort(cityRequestParameters.OrderBy)
                .Skip((cityRequestParameters.PageNumber - 1) * cityRequestParameters.PageSize)
                .Take(cityRequestParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<City>(cities, count, cityRequestParameters.PageNumber, cityRequestParameters.PageSize);
        }

        public async Task<City> GetCityByIdAsync(Guid cityId, bool trackChanges) =>
            await FindByCondition(c => c.CityId.Equals(cityId), trackChanges).SingleOrDefaultAsync();

        public async Task<City> GetCityByNameAsync(string cityName, bool trackChanges)=> 
            await FindByCondition(c => c.CityName.Equals(cityName), trackChanges).SingleOrDefaultAsync();

        public async Task<PagedList<City>> GetCitiesByGovernmentIdAsync(Guid governmentId, CityRequestParameters cityRequestParameters, bool trackChanges)
        {
            var cities = await FindByCondition(c => c.GovernmentId.Equals(governmentId), trackChanges)
                .Sort(cityRequestParameters.OrderBy)
                .Skip((cityRequestParameters.PageNumber - 1) * cityRequestParameters.PageSize)
                .Take(cityRequestParameters.PageSize)
                .ToListAsync();
            var count = await FindByCondition(c => c.GovernmentId.Equals(governmentId), trackChanges).CountAsync();
            return new PagedList<City>(cities, count, cityRequestParameters.PageNumber, cityRequestParameters.PageSize);
        }

        public void CreateCity(City city) => Create(city);
        public void DeleteCity(City city) => Delete(city);
        public void UpdateCity(City city) => Update(city);
    }

}
