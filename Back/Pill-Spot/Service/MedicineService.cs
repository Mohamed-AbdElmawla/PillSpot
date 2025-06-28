using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    internal sealed class MedicineService : IMedicineService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public MedicineService(IRepositoryManager repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<(IEnumerable<MedicineDto> medicines, MetaData metaData)> GetAllMedicinesAsync(MedicinesRequestParameters medicinesRequestParameters, bool trackChanges)
        {
            var medicinesWithMetaData = await _repository.MedicineRepository.GetAllMedicinesAsync(medicinesRequestParameters, trackChanges);

            var medicinesDto = _mapper.Map<IEnumerable<MedicineDto>>(medicinesWithMetaData);

            return (medicines: medicinesDto, metaData: medicinesWithMetaData.MetaData);
        }

        public async Task<MedicineDto> CreateMedicineAsync(MedicineForCreationDto medicineForCreationDto, bool trackChanges)
        {
            var subCategory = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync(medicineForCreationDto.SubCategoryId, trackChanges);
            if (subCategory == null)
                throw new SubCategoryNotFoundException(medicineForCreationDto.SubCategoryId);
            var medicineEntity = _mapper.Map<Medicine>(medicineForCreationDto);
            _repository.MedicineRepository.CreateMedicine(medicineEntity);
            medicineEntity.ImageURL = await _fileService.AddProductImageIfNotNull(medicineForCreationDto.Image);
            await _repository.SaveAsync();
            return _mapper.Map<MedicineDto>(medicineEntity);
        }

        public async Task DeleteMedicineAsync(Guid productId, bool trackChanges)
        {
            var medicineEntity = await GetMedicineByIdAndCheckIfItExist(productId, trackChanges);

            _repository.MedicineRepository.DeleteMedicine(medicineEntity);
            await _repository.SaveAsync();
        }

        public async Task<MedicineDto> GetMedicineAsync(Guid productId, bool trackChanges)
        {
            var medicineEntity = await GetMedicineByIdAndCheckIfItExist(productId, trackChanges);

            return _mapper.Map<MedicineDto>(medicineEntity);
        }

        public async Task UpdateMedicineAsync(Guid productId, MedicineForUpdateDto medicineForUpdateDto, bool trackChanges)
        {
            if (medicineForUpdateDto.SubCategoryId.HasValue)
            {
                var subCategory = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync((Guid)medicineForUpdateDto.SubCategoryId, trackChanges);
                if (subCategory == null)
                    throw new SubCategoryNotFoundException((Guid)medicineForUpdateDto.SubCategoryId);
            }
            var medicineEntity = await GetMedicineByIdAndCheckIfItExist(productId, trackChanges);

            _mapper.Map(medicineForUpdateDto, medicineEntity);
            if(medicineForUpdateDto.Image != null)
                medicineEntity.ImageURL = await _fileService.AddProductImageIfNotNull(medicineForUpdateDto.Image);
            
            await _repository.SaveAsync();
        }
        private async Task<Medicine> GetMedicineByIdAndCheckIfItExist(Guid productId, bool trackChanges)
        {
            var medicineEntity = await _repository.MedicineRepository.GetMedicineAsync(productId, trackChanges);
            if (medicineEntity == null)
                throw new MedicineNotFoundException(productId);
            return medicineEntity;
        }
    }

}
