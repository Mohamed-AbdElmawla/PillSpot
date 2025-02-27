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
            await FindAll(trackChanges).ToListAsync();

        public async Task<SubCategory> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, bool trackChanges) =>
            await FindByCondition(sc => sc.SubCategoryID.Equals(subCategoryId) && sc.CategoryID.Equals(categoryId), trackChanges).FirstOrDefaultAsync();

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId, bool trackChanges) =>
            await FindByCondition(sc => sc.CategoryID.Equals(categoryId), trackChanges).ToListAsync();

        public void CreateSubCategory(SubCategory subCategory)=> Create(subCategory);

        public void UpdateSubCategory(SubCategory subCategory) => Update(subCategory);

        public void DeleteSubCategory(SubCategory subCategory) => Delete(subCategory);
    }
}
