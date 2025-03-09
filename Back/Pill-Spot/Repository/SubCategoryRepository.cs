using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SubCategoryRepository : RepositoryBase<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).Include(sc => sc.Category).ToListAsync();

        public async Task<SubCategory> GetSubCategoryByIdAsync(Guid categoryId, Guid subCategoryId, bool trackChanges) =>
            await FindByCondition(sc => sc.SubCategoryId.Equals(subCategoryId) && sc.CategoryId.Equals(categoryId), trackChanges).Include(sc => sc.Category).FirstOrDefaultAsync();

        public async Task<SubCategory> GetSubCategoryByIdAsync(Guid subCategoryId, bool trackChanges) =>
            await FindByCondition(sc => sc.SubCategoryId.Equals(subCategoryId), trackChanges).Include(sc => sc.Category).FirstOrDefaultAsync();

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(Guid categoryId, bool trackChanges) =>
            await FindByCondition(sc => sc.CategoryId.Equals(categoryId), trackChanges).Include(sc => sc.Category).ToListAsync();

        public void CreateSubCategory(SubCategory subCategory) => Create(subCategory);

        public void UpdateSubCategory(SubCategory subCategory) => Update(subCategory);

        public void DeleteSubCategory(SubCategory subCategory) => Delete(subCategory);
    }
}
