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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId, bool trackChanges) =>
           await FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges).FirstOrDefaultAsync();

        public void CreateCategory(Category category) => Create(category);
        public void UpdateCategory(Category category) => Update(category);

        public void DeleteCategory(Category category) => Delete(category);
    }
}
