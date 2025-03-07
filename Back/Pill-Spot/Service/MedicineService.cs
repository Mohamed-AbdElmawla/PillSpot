using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class MedicineService : IMedicineService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public MedicineService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MedicineDto> CreateMedicineAsync(MedicineForCreationDto medicine)
        {
            var medicineEntity = _mapper.Map<Medicine>(medicine);
            _repository.MedicineRepository.CreateMedicine(medicineEntity);
            await _repository.SaveAsync();
            return _mapper.Map<MedicineDto>(medicineEntity);
        }

        public async Task DeleteMedicine(Guid productId, bool trackChanges)
        {
            var medicine = await _repository.MedicineRepository.GetMedicineAsync(productId, trackChanges);
            if (medicine == null)
                throw new MedicineNotFoundException(productId);

            _repository.MedicineRepository.DeleteMedicine(medicine);
            await _repository.SaveAsync();
        }

        public async Task<MedicineDto> GetMedicineAsync(Guid productId, bool trackChanges)
        {
            var medicine = await _repository.MedicineRepository.GetMedicineAsync(productId, trackChanges);
            if (medicine == null)
                throw new MedicineNotFoundException(productId);

            return _mapper.Map<MedicineDto>(medicine);
        }
    }

}
