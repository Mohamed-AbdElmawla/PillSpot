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
    internal sealed class PharmacyMedicineService : IPharmacyMedicineService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<IServiceManager> _logger;
        private readonly IMapper _mapper;
        public PharmacyMedicineService(IRepositoryManager repository, ILogger<IServiceManager> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PharmacyMedicineDto>> GetMedicinesAsync(int pharmacyId, bool trackChanges)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, trackChanges);
            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);
            var medicines = await _repository.PharmacyMedicine.GetMedicinesAsync(pharmacyId, trackChanges);
            var medicinesDto = _mapper.Map<IEnumerable<PharmacyMedicineDto>>(medicines);
            return medicinesDto;
        }
        public async Task<PharmacyMedicineDto> GetMedicineAsync(int pharmacyId, int medicineId, bool trackChanges)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, trackChanges);
            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);
            var medicine = await _repository.PharmacyMedicine.GetMedicineAsync(pharmacyId, medicineId, trackChanges);
            if (medicine is null)
                throw new MedicineNotFoundException(medicineId);
            var medicineDto = _mapper.Map<PharmacyMedicineDto>(medicine);
            return medicineDto;
        }

        public async Task<PharmacyMedicineDto> CreatePharmacyMedicineAsync(int pharmacyId, PharmacyMedicineForCreationDto pharmacyMedicineCreationDto, bool trackChanges)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);

            var medicine = await _repository.Medicine.GetMedicineAsync(pharmacyMedicineCreationDto.MedicineId, trackChanges);

            if (medicine is null)
                throw new MedicineNotFoundException(pharmacyMedicineCreationDto.MedicineId);

            var pharmacyMedicine = _mapper.Map<PharmacyMedicine>(pharmacyMedicineCreationDto);

            _repository.PharmacyMedicine.CreatePharmacyMedicine(pharmacyId, pharmacyMedicine);

            await _repository.SaveAsync();

            var pharmacyMedicineToReturn = _mapper.Map<PharmacyMedicineDto>(pharmacyMedicine);

            return pharmacyMedicineToReturn;
        }

        public async Task DeletePharmacyMedicine(int pharmacyId, int medicineId, bool trackChanges)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, trackChanges);

            if (pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);

            var medicine = await _repository.PharmacyMedicine.GetMedicineAsync(pharmacyId, medicineId, trackChanges);

            if (medicine is null)
                throw new MedicineNotFoundException(medicineId);
            _repository.PharmacyMedicine.DeletePharmacyMedicine(medicine);
            await _repository.SaveAsync();
        }

        public async Task UpdatePharmacyMedicine(int pharmacyId, int medicineId, PharmacyMedicineForUpdateDto pharmacyMedicineForUpdate, bool phTrackChanges, bool phMedTrackChanges)
        {
            var pharmacy = await _repository.Pharmacy.GetPharmacyAsync(pharmacyId, phTrackChanges);

            if(pharmacy is null)
                throw new PharmacyNotFoundException(pharmacyId);

            var medicine = await _repository.PharmacyMedicine.GetMedicineAsync(pharmacyId, medicineId, phMedTrackChanges);

            if (medicine is null)
                throw new MedicineNotFoundException(medicineId);

            _mapper.Map(pharmacyMedicineForUpdate, medicine);

            await _repository.SaveAsync();
        }
    }
}
