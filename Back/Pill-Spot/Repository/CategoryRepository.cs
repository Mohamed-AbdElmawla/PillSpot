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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<Category>> GetAllCategoriesAsync(CategoriesRequestParameters categoriesRequestParameters, bool trackChanges)
        {
            var categories = await FindAll(trackChanges)
                .Skip((categoriesRequestParameters.PageNumber - 1) * categoriesRequestParameters.PageSize)
                .Take(categoriesRequestParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Category>(categories, count, categoriesRequestParameters.PageNumber, categoriesRequestParameters.PageSize);
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId, bool trackChanges) =>
           await FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges).FirstOrDefaultAsync();

        public void CreateCategory(Category category) => Create(category);
        public void UpdateCategory(Category category) => Update(category);

        public void DeleteCategory(Category category) => Delete(category);
    }
}
