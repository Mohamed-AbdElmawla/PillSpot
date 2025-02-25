using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CityService : ICityService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CityService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<CityDto> cities, MetaData metaData)> GetAllCitiesAsync(CityRequestParameters cityRequestParameters, bool trackChanges)
        {
            var citiesWithMetaData = await _repository.CityRepository.GetAllCitiesAsync(cityRequestParameters, trackChanges);

            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(citiesWithMetaData);

            return (cities: citiesDto, metaData: citiesWithMetaData.MetaData);
        }

        public async Task<CityDto> GetCityByIdAsync(Guid cityId, bool trackChanges)
        {
            var cityEntity = await _repository.CityRepository.GetCityByIdAsync(cityId, trackChanges);

            if (cityEntity == null) 
                throw new CityNotFoundException(cityId);

            return _mapper.Map<CityDto>(cityEntity);
        }

        public async Task<IEnumerable<CityDto>> GetCitiesByGovernmentIdAsync(Guid governmentId, CityRequestParameters cityRequestParameters, bool trackChanges)
        {
            var government = await _repository.GovernmentRepository.GetGovernmentByIdAsync(governmentId, trackChanges);
            if(government == null)
                throw new GovernmentNotFoundException(governmentId);
            var cities = await _repository.CityRepository.GetCitiesByGovernmentIdAsync(governmentId, cityRequestParameters, trackChanges);
            return _mapper.Map<IEnumerable<CityDto>>(cities);
        }

        public async Task<Guid> CreateCityAsync(CityForCreationDto city, bool trackChanges)
        {
            var cityEntity = await _repository.CityRepository.GetCityByNameAsync(city.CityName, trackChanges);
            if (cityEntity == null)
            {
                cityEntity = _mapper.Map<City>(city);
                _repository.CityRepository.CreateCity(cityEntity);
            }
            return cityEntity.CityId;
        }

        public async Task UpdateCityAsync(Guid cityId, CityForUpdateDto city, bool trackChanges)
        {
            var cityEntity = await _repository.CityRepository.GetCityByIdAsync(cityId, trackChanges);
            if (cityEntity == null)
                throw new CityNotFoundException(cityId);
            _mapper.Map(city, cityEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteCityAsync(Guid cityId, bool trackChanges)
        {
            var cityEntity = await _repository.CityRepository.GetCityByIdAsync(cityId, trackChanges);
            if (cityEntity == null)
                throw new CityNotFoundException(cityId);
            _repository.CityRepository.DeleteCity(cityEntity);
            await _repository.SaveAsync();
        }
    }
}
