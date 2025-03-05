using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(bool trackChanges)
        {
            var subCategories = await _repository.SubCategoryRepository.GetAllSubCategoriesAsync(trackChanges); ;
            var subCategoriesDto = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
            return subCategoriesDto;
        }

        public async Task<SubCategoryDto> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, bool trackChanges)
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

        public async Task<IEnumerable<SubCategoryDto>> GetSubCategoriesByCategoryIdAsync(int categoryId, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);
            var subCategories = await _repository.SubCategoryRepository.GetSubCategoriesByCategoryIdAsync(categoryId, trackChanges);
            var subCategoriesDto = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
            return subCategoriesDto;
        }
        public async Task CreateSubCategory(int categoryId, SubCategoryForCreateDto subCategoryForCreateDto, bool trackChanges)
        {
            var categoryEntity = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);

            if (categoryEntity == null)
                throw new CategoryNotFoundException(categoryId);

            var subCategoryEntity = _mapper.Map<SubCategory>(subCategoryForCreateDto);

            subCategoryEntity.CategoryId = categoryId;

            _repository.SubCategoryRepository.CreateSubCategory(subCategoryEntity);

            await _repository.SaveAsync();
        }

        public async Task UpdateSubCategory(int categoryId, int subCategoryId, SubCategoryForUpdateDto subCategoryForUpdateDto, bool trackChanges)
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

        public async Task DeleteSubCategory(int categoryId, int subCategoryId, bool trackChanges) 
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
