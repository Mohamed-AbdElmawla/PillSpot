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
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId, bool trackChanges);
        Task CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto);
        Task UpdateCategory(int categoryId, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges);
        Task DeleteCategory(int categoryId, bool trackChanges);
    }
}
