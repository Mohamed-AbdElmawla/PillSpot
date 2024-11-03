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
    internal sealed class MedicineService : IMedicineService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<IServiceManager> _logger;
        private readonly IMapper _mapper;
        public MedicineService(IRepositoryManager repository, ILogger<IServiceManager> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<MedicineDto> CreateMedicineAsync(MedicineForCreationDto medicine)
        {
            var medicineEntitiy = _mapper.Map<Medicine>(medicine);
            _repository.Medicine.CreateMedicine(medicineEntitiy);
            await _repository.SaveAsync();
            var medicineToReturn = _mapper.Map<MedicineDto>(medicineEntitiy);
            return medicineToReturn;
        }

        public async Task<MedicineDto> GetMedicineAsync(int medicineId, bool trackChanges)
        {
            var medicine = await _repository.Medicine.GetMedicineAsync(medicineId, trackChanges);
            if (medicine is null)
                throw new MedicineNotFoundException(medicineId);
            var medicineDto = _mapper.Map<MedicineDto>(medicine);
            return medicineDto;
        }

        public async Task DeleteMedicine(int medicineId, bool trackChanges)
        {
            var medicine = await _repository.Medicine.GetMedicineAsync(medicineId, trackChanges);

            if (medicine is null)
                throw new MedicineNotFoundException(medicineId);
            _repository.Medicine.DeleteMedicine(medicine);
            await _repository.SaveAsync();
        }
    }
}
