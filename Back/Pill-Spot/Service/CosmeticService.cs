using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CosmeticService : ICosmeticService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public CosmeticService(IRepositoryManager repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<CosmeticDto> CreateCosmeticAsync(CosmeticForCreationDto cosmeticForCreationDto, bool trackChanges)
        {
            var subCategory = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync(cosmeticForCreationDto.SubCategoryId, trackChanges);
            if (subCategory == null)
                throw new SubCategoryNotFoundException(cosmeticForCreationDto.SubCategoryId);
            var cosmeticEntity = _mapper.Map<Cosmetic>(cosmeticForCreationDto);
            _repository.CosmeticRepository.CreateCosmetic(cosmeticEntity);

            cosmeticEntity.ImageURL = await _fileService.AddProductImageIfNotNull(cosmeticForCreationDto.Image);

            await _repository.SaveAsync();
            return _mapper.Map<CosmeticDto>(cosmeticEntity);
        }

        public async Task DeleteCosmeticAsync(Guid productId, bool trackChanges)
        {
            var cosmeticEntity = await GetCosmeticByIdAndCheckIfItExist(productId, trackChanges);

            _repository.CosmeticRepository.DeleteCosmetic(cosmeticEntity);
            await _repository.SaveAsync();
        }

        public async Task<CosmeticDto> GetCosmeticAsync(Guid productId, bool trackChanges)
        {
            var cosmeticEntity = await GetCosmeticByIdAndCheckIfItExist(productId, trackChanges);

            return _mapper.Map<CosmeticDto>(cosmeticEntity);
        }

        public async Task UpdateCosmeticAsync(Guid productId, CosmeticForUpdateDto cosmeticForUpdateDto, bool trackChanges)
        {
            if (cosmeticForUpdateDto.SubCategoryId.HasValue)
            {
                var subCategory = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync((Guid)cosmeticForUpdateDto.SubCategoryId, trackChanges);
                if (subCategory == null)
                    throw new SubCategoryNotFoundException((Guid)cosmeticForUpdateDto.SubCategoryId);
            }
            var cosmeticEntity = await GetCosmeticByIdAndCheckIfItExist(productId, trackChanges);
             _mapper.Map(cosmeticForUpdateDto, cosmeticEntity);
            if (cosmeticForUpdateDto.Image != null)
                cosmeticEntity.ImageURL = await _fileService.AddProductImageIfNotNull(cosmeticForUpdateDto.Image);
            await _repository.SaveAsync();
        }
        private async Task<Cosmetic> GetCosmeticByIdAndCheckIfItExist(Guid productId, bool trackChanges)
        {
            var cosmeticEntity = await _repository.CosmeticRepository.GetCosmeticAsync(productId, trackChanges);
            if (cosmeticEntity == null)
                throw new CosmeticNotFoundException(productId);
            return cosmeticEntity;
        }
    }
}
