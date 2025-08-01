﻿using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface ISubCategoryService
    {
        Task<(IEnumerable<SubCategoryDto> subCategories, MetaData metaData)> GetAllSubCategoriesAsync(SubCategoriesRequestParameters subCategoriesRequestParameters, bool trackChanges);
        Task<SubCategoryDto> GetSubCategoryByIdAsync(Guid categoryId, Guid subCategoryId, bool trackChanges);
        Task<(IEnumerable<SubCategoryDto> subCategories, MetaData metaData)> GetSubCategoriesByCategoryIdAsync(Guid categoryId, SubCategoriesRequestParameters subCategoriesRequestParameters, bool trackChanges);
        Task CreateSubCategory(Guid categoryId, SubCategoryForCreateDto subCategoryForCreateDto, bool trackChanges);
        Task UpdateSubCategory(Guid categoryId, Guid subCategoryId, SubCategoryForUpdateDto subCategoryForUpdateDto, bool trackChanges);
        Task DeleteSubCategory(Guid categoryId, Guid subCategoryId, bool trackChanges);
    }
}
