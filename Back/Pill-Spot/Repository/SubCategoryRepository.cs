using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class SubCategoryRepository : RepositoryBase<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<SubCategory>> GetAllSubCategoriesAsync(SubCategoriesRequestParameters subCategoriesRequestParameters, bool trackChanges)
        {
            var subCategories = await FindAll(trackChanges)
                .Skip((subCategoriesRequestParameters.PageNumber - 1) * subCategoriesRequestParameters.PageSize)
                .Take(subCategoriesRequestParameters.PageSize)
                .Include(sc => sc.Category)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<SubCategory>(subCategories, count, subCategoriesRequestParameters.PageNumber, subCategoriesRequestParameters.PageSize);
        }

        public async Task<SubCategory> GetSubCategoryByIdAsync(Guid categoryId, Guid subCategoryId, bool trackChanges) =>
            await FindByCondition(sc => sc.SubCategoryId.Equals(subCategoryId) && sc.CategoryId.Equals(categoryId), trackChanges).Include(sc => sc.Category).FirstOrDefaultAsync();

        public async Task<SubCategory> GetSubCategoryByIdAsync(Guid subCategoryId, bool trackChanges) =>
            await FindByCondition(sc => sc.SubCategoryId.Equals(subCategoryId), trackChanges).Include(sc => sc.Category).FirstOrDefaultAsync();

        public async Task<PagedList<SubCategory>> GetSubCategoriesByCategoryIdAsync(Guid categoryId, SubCategoriesRequestParameters subCategoriesRequestParameters, bool trackChanges)
        {
            var subCategories = await FindByCondition(sc => sc.CategoryId.Equals(categoryId), trackChanges)
                .Skip((subCategoriesRequestParameters.PageNumber - 1) * subCategoriesRequestParameters.PageSize)
                .Take(subCategoriesRequestParameters.PageSize)
                .Include(sc => sc.Category)
                .ToListAsync();

            var count = await FindByCondition(sc => sc.CategoryId.Equals(categoryId), trackChanges).CountAsync();

            return new PagedList<SubCategory>(subCategories, count, subCategoriesRequestParameters.PageNumber, subCategoriesRequestParameters.PageSize);
        }

        public void CreateSubCategory(SubCategory subCategory) => Create(subCategory);

        public void UpdateSubCategory(SubCategory subCategory) => Update(subCategory);

        public void DeleteSubCategory(SubCategory subCategory) => Delete(subCategory);
    }
}
