using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PharmacyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public IEnumerable<PharmacyDto> GetAllPharmacies(bool trackChanges)
        {
            var pharmacies = _repository.Pharmacy.GetAllPharmacies(trackChanges);
            var pharmaciesDto = _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);
            return pharmaciesDto;
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
