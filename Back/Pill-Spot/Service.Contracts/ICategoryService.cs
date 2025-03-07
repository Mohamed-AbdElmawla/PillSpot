using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId, bool trackChanges);
        Task CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto);
        Task UpdateCategory(Guid categoryId, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges);
        Task DeleteCategory(Guid categoryId, bool trackChanges);
    }
}
