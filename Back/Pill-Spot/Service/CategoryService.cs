﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class CategoryService: ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetAllCategoriesAsync(CategoriesRequestParameters categoriesRequestParameters,bool trackChanges)
        {
            var categoriesWithMetaData = await _repository.CategoryRepository.GetAllCategoriesAsync(categoriesRequestParameters, trackChanges);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categoriesWithMetaData);
            return (categories: categoriesDto, metaData: categoriesWithMetaData.MetaData);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return categoryDto;
        }

        public async Task CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryForCreateDto);
            _repository.CategoryRepository.CreateCategory(categoryEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateCategory(Guid categoryId, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);
            _mapper.Map(categoryForUpdateDto, categoryEntity);
            await _repository.SaveAsync();

        }

        public async Task DeleteCategory(Guid categoryId, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);
            _repository.CategoryRepository.DeleteCategory(categoryEntity);
            await _repository.SaveAsync();
        }
    }
}