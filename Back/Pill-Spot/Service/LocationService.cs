using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class LocationService : ILocationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ICityService _cityService;
        private readonly IGovernmentService _governmentService;
        private readonly IMapper _mapper;
        public LocationService(IRepositoryManager repository, IMapper mapper, ICityService cityService, IGovernmentService governmentService)
        {
            _repository = repository;
            _mapper = mapper;
            _cityService = cityService;
            _governmentService = governmentService;
        }
        public async Task<Guid> CreateLocationAsync(LocationForCreationDto location, bool trackChanges)
        {
            var governmentForCreation = new GovernmentForCreationDto { GovernmentName = location.GovernmentName };
            var governmentId = await _governmentService.CreateGovernmentAsync(governmentForCreation, trackChanges);

            var cityForCreation = new CityForCreationDto { CityName = location.CityName, GovernmentId = governmentId };
            var cityId = await _cityService.CreateCityAsync(cityForCreation, trackChanges);
            var cityExists = await _repository.CityRepository.GetCityByIdAsync(cityId, trackChanges);
            var locationEntity = _mapper.Map<Location>(location);
            locationEntity.CityId = cityId;
            _repository.LocationRepository.CreateLocation(locationEntity);

            return locationEntity.LocationId;
        }

        public async Task DeleteLocationAsync(Guid locationId, bool trackChanges)
        {
            var locationEntity = await _repository.LocationRepository.GetLocationByIdAsync(locationId, trackChanges);
            if (locationEntity == null)
                throw new LocationNotFoundException(locationId);
            _repository.LocationRepository.DeleteLocation(locationEntity);
            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<LocationDto> locations, MetaData metaData)> GetAllLocationsAsync(LocationRequestParameters locationRequestParameters, bool trackChanges)
        {
            var locationsWithMetaData = await _repository.LocationRepository.GetAllLocationsAsync(locationRequestParameters, trackChanges);

            var locationsDto = _mapper.Map<IEnumerable<LocationDto>>(locationsWithMetaData);

            return (locations: locationsDto, metaData: locationsWithMetaData.MetaData);
        }

        public async Task<LocationDto> GetLocationByIdAsync(Guid locationId, bool trackChanges)
        {
            var locationEntity = await _repository.LocationRepository.GetLocationByIdAsync(locationId, trackChanges);

            if (locationEntity == null)
                throw new LocationNotFoundException(locationId);

            var locationDto = _mapper.Map<LocationDto>(locationEntity);

            return locationDto;
        }

        public async Task UpdateLocationAsync(Guid locationId, LocationForCreationDto location, bool trackChanges)
        {
            var locationEntity = await _repository.LocationRepository.GetLocationByIdAsync(locationId, trackChanges);
            if (locationEntity == null)
                throw new LocationNotFoundException(locationId);
            _mapper.Map(location, locationEntity);
            await _repository.SaveAsync();
        }
    }
}
