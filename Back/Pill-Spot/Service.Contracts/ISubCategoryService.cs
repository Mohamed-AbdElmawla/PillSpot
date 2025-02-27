using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(bool trackChanges);
        Task<SubCategoryDto> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, bool trackChanges);
        Task<IEnumerable<SubCategoryDto>> GetSubCategoriesByCategoryIdAsync(int categoryId, bool trackChanges);
        Task CreateSubCategory(int categoryId, SubCategoryForCreateDto subCategoryForCreateDto, bool trackChanges);
        Task UpdateSubCategory(int categoryId, int subCategoryId, SubCategoryForUpdateDto subCategoryForUpdateDto, bool trackChanges);
        Task DeleteSubCategory(int categoryId, int subCategoryId, bool trackChanges);
    }
}
