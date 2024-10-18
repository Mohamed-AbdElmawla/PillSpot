using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    

        public PharmacyDto CreatePharmacy(PharmacyForCreationDto pharmacy)
        {
            var pharmacyEntitiy = _mapper.Map<Pharmacy>(pharmacy);
            _repository.Pharmacy.CreatePharmacy(pharmacyEntitiy);
            _repository.Save();
            var pharmacyToReturn = _mapper.Map<PharmacyDto>(pharmacyEntitiy);
            return pharmacyToReturn;
        }

        public (IEnumerable<PharmacyDto> pharmacies, string ids) CreatePharmacyCollection(IEnumerable<PharmacyForCreationDto> pharmacyCollection)
        {
            if (pharmacyCollection is null)
                throw new PharmacyCollectionBadRequest();
            var pharmaciesEntities = _mapper.Map<IEnumerable<Pharmacy>>(pharmacyCollection);
            foreach(var pharmacy in pharmaciesEntities)
            {
                _repository.Pharmacy.CreatePharmacy(pharmacy);
            }
            _repository.Save();
            var pharmacyCollectionToReturn = _mapper.Map<IEnumerable<PharmacyDto>>(pharmaciesEntities);
            var ids = string.Join(",", pharmacyCollectionToReturn.Select(ph => ph.Id));
            return (pharmacies: pharmacyCollectionToReturn, ids: ids);
        }

        public IEnumerable<PharmacyDto> GetAllPharmacies(bool trackChanges)
        {
            var pharmacies = _repository.Pharmacy.GetAllPharmacies(trackChanges);
            var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);
            return pharmaciesDto;
        }

        public IEnumerable<PharmacyDto> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            if(ids is null)
                throw new IdParametersBadRequestException();
            var pharmacies = _repository.Pharmacy.GetByIds(ids, trackChanges);
            if (ids.Count() != pharmacies.Count())
                throw new CollectionByIdsBadRequestException();
            var pharmaciesToReturn = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);
            return pharmaciesToReturn;
        }

        public PharmacyDto GetPharmacy(int pharmacyId, bool trackChanges)
        {
            var pharmacy = _repository.Pharmacy.GetPharmacy(pharmacyId, trackChanges);
            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);
            var pharmacyDto = _mapper.Map<PharmacyDto>(pharmacy);
            return pharmacyDto;
        }
    }
}
