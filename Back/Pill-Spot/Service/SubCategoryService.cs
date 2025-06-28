using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public SubCategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<SubCategoryDto> subCategories, MetaData metaData)> GetAllSubCategoriesAsync(SubCategoriesRequestParameters subCategoriesRequestParameters,bool trackChanges)
        {
            var subCategoriesWithMetaData = await _repository.SubCategoryRepository.GetAllSubCategoriesAsync(subCategoriesRequestParameters, trackChanges); ;
            var subCategoriesDto = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategoriesWithMetaData);
            return (subCategories: subCategoriesDto, metaData: subCategoriesWithMetaData.MetaData);
        }

        public async Task<SubCategoryDto> GetSubCategoryByIdAsync(Guid categoryId, Guid subCategoryId, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);

            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);

            var subCategoryEntity = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync(categoryId ,subCategoryId, trackChanges);

            if(subCategoryEntity == null)
                throw new SubCategoryNotFoundException(subCategoryId);

            var subCategoryDto = _mapper.Map<SubCategoryDto>(subCategoryEntity);
            return subCategoryDto;
        }

        public async Task<(IEnumerable<SubCategoryDto> subCategories, MetaData metaData)> GetSubCategoriesByCategoryIdAsync(Guid categoryId, SubCategoriesRequestParameters subCategoriesRequestParameters, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);
            var subCategoriesWithMetaData = await _repository.SubCategoryRepository.GetSubCategoriesByCategoryIdAsync(categoryId, subCategoriesRequestParameters, trackChanges);
            var subCategoriesDto = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategoriesWithMetaData);
            return (subCategories: subCategoriesDto, metaData: subCategoriesWithMetaData.MetaData);
        }
        public async Task CreateSubCategory(Guid categoryId, SubCategoryForCreateDto subCategoryForCreateDto, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);

            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);

            var subCategoryEntity = _mapper.Map<SubCategory>(subCategoryForCreateDto);

            subCategoryEntity.CategoryId = categoryId;

            _repository.SubCategoryRepository.CreateSubCategory(subCategoryEntity);

            await _repository.SaveAsync();
        }

        public async Task UpdateSubCategory(Guid categoryId, Guid subCategoryId, SubCategoryForUpdateDto subCategoryForUpdateDto, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);

            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);

            var subCategoryEntity = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync(categoryId, subCategoryId, trackChanges);

            if (subCategoryEntity == null)
                throw new SubCategoryNotFoundException(subCategoryId);

            _mapper.Map(subCategoryForUpdateDto, subCategoryEntity);

            await _repository.SaveAsync();
        }

        public async Task DeleteSubCategory(Guid categoryId, Guid subCategoryId, bool trackChanges) 
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);

            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);

            var subCategoryEntity = await _repository.SubCategoryRepository.GetSubCategoryByIdAsync(categoryId, subCategoryId, trackChanges);
            if(subCategoryEntity == null)
                throw new SubCategoryNotFoundException(subCategoryId);
            _repository.SubCategoryRepository.DeleteSubCategory(subCategoryEntity);
            await _repository.SaveAsync();
        }
    }
}
