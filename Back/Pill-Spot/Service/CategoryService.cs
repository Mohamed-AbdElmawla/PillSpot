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
    public class CategoryService: ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _repository.CategoryRepository.GetAllCategoriesAsync(trackChanges);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId, bool trackChanges)
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

        public async Task UpdateCategory(int categoryId, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);
            _mapper.Map(categoryForUpdateDto, categoryEntity);
            await _repository.SaveAsync();

        }

        public async Task DeleteCategory(int categoryId, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);
            _repository.CategoryRepository.DeleteCategory(categoryEntity);
            await _repository.SaveAsync();
        }
    }
}