using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    internal sealed  class PharmacyService : IPharmacyService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        public PharmacyService(IRepositoryManager repository, IMapper mapper,
            UserManager<User> userManager, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
        }

        public async Task<PharmacyDto> CreatePharmacyAsync(PharmacyForCreationDto pharmacy)

        {
            var pharmacyEntitiy = _mapper.Map<Pharmacy>(pharmacy);
            _repository.PharmacyRepository.CreatePharmacy(pharmacyEntitiy);
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
                _repository.PharmacyRepository.CreatePharmacy(pharmacy);
            }
            await _repository.SaveAsync();
            var pharmacyCollectionToReturn = _mapper.Map<IEnumerable<PharmacyDto>>(pharmaciesEntities);
            var ids = string.Join(",", pharmacyCollectionToReturn.Select(ph => ph.PharmacyId));
            return (pharmacies: pharmacyCollectionToReturn, ids: ids);
        }

        public async Task DeletePharmacy(Guid pharmacyId, bool trackChanges)
        {
            var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);

            pharmacy.IsDeleted = true;

            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetAllPharmaciesAsync(PharmaciesParameters pharmaciesparameters, bool trackChanges)
        {
            var pharmacies = await _repository.PharmacyRepository.GetAllPharmaciesAsync(pharmaciesparameters, trackChanges);
            var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);
            return (pharmacies: pharmaciesDto, pharmacies.MetaData);
        }


        public async Task<(IEnumerable<PharmacyDto> pharmacies, MetaData metaData)> GetByIdsAsync(IEnumerable<Guid> ids, PharmaciesParameters pharmaciesparameters, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var pharmacies = await _repository.PharmacyRepository.GetByIdsAsync(ids, pharmaciesparameters, trackChanges);

            if (ids.Count() != pharmacies.Count())
                throw new CollectionByIdsBadRequestException();

            var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);

            return (pharmacies: pharmaciesDto, pharmacies.MetaData);
        }

        public async Task<PharmacyDto> GetPharmacyAsync(Guid pharmacyId, bool trackChanges)
        {
            var pharmacy = await _repository.PharmacyRepository.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);

            var pharmacyDto = _mapper.Map<PharmacyDto>(pharmacy);
            return pharmacyDto;
        }

        public async Task UpdatePharmacy(Guid pharmacyId, PharmacyForUpdateDto pharmacyForUpdate, bool trackChanges)
        {
            var pharmacyEntity = await _repository.PharmacyRepository.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacyEntity is null)
                throw new PharmacyNotFoundException(pharmacyId);

            _mapper.Map(pharmacyForUpdate, pharmacyEntity);

            if (_fileService != null && pharmacyForUpdate.logo != null)
            {
                string logoPath = await _fileService.SaveFileAsync(pharmacyForUpdate.logo, "Logos");
                pharmacyEntity.LogoURL = logoPath;
            }

            await _repository.SaveAsync();
        }
    }
}
