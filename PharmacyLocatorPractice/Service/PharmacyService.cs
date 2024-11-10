using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace Service
{
    internal sealed class PharmacyService : IPharmacyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<IServiceManager> _logger;
        private readonly IMapper _mapper;
        public PharmacyService(IRepositoryManager repository, ILogger<IServiceManager> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PharmacyDto> CreatePharmacyAsync(PharmacyForCreationDto pharmacy)

        {
            var pharmacyEntitiy = _mapper.Map<Pharmacy>(pharmacy);
            _repository.Pharmacy.CreatePharmacy(pharmacyEntitiy);
            await _repository.SaveAsync();
            var pharmacyToReturn = _mapper.Map<PharmacyDto>(pharmacyEntitiy);
            return pharmacyToReturn;
        }

        public async Task<(IEnumerable<PharmacyDto> pharmacies, string ids)> CreatePharmacyCollectionAsync(IEnumerable<PharmacyForCreationDto> pharmacyCollection)
        {
            if (pharmacyCollection is null)
                throw new PharmacyCollectionBadRequest();
            var pharmaciesEntities = _mapper.Map<IEnumerable<Pharmacy>>(pharmacyCollection);
            foreach (var pharmacy in pharmaciesEntities)
            {
                _repository.Pharmacy.CreatePharmacy(pharmacy);
            }
            await _repository.SaveAsync();
            var pharmacyCollectionToReturn = _mapper.Map<IEnumerable<PharmacyDto>>(pharmaciesEntities);
            var ids = string.Join(",", pharmacyCollectionToReturn.Select(ph => ph.PharmacyId));
            return (pharmacies: pharmacyCollectionToReturn, ids: ids);
        }

        public async Task DeletePharmacy(string pharmacyId, bool trackChanges)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);

            _repository.Pharmacy.DeletePharmacy(pharmacy);
            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<PharmacyDto> Pharmacies, MetaData metaData)> GetAllPharmaciesAsync(bool trackChanges, PharmaciesParameters pharmaciesparameters)
        {
            var pharmacies = await _repository.Pharmacy.GetAllPharmaciesAsync(trackChanges, pharmaciesparameters);
            var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);
            return (Pharmacies: pharmaciesDto, pharmacies.MetaData);
        }


        public async Task<IEnumerable<PharmacyDto>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var pharmacies = await _repository.Pharmacy.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != pharmacies.Count())
                throw new CollectionByIdsBadRequestException();
            var pharmaciesToReturn = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);
            return pharmaciesToReturn;
        }

        public async Task<PharmacyDto> GetPharmacyAsync(string pharmacyId, bool trackChanges)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);

            var pharmacyDto = _mapper.Map<PharmacyDto>(pharmacy);
            return pharmacyDto;
        }

        public async Task UpdatePharmacy(string pharmacyId, PharmacyForUpdateDto pharmacyForUpdate, bool trackChanges)
        {
            var pharmacyEntity = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacyEntity is null)
                throw new PharmacyNotFoundException(pharmacyId);

            _mapper.Map(pharmacyForUpdate, pharmacyEntity);

            await _repository.SaveAsync();
        }
    }
}
