using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(bool trackChanges);
        Task<SubCategory> GetSubCategoryByIdAsync(int categoryId, int subCategoryId, bool trackChanges);
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId, bool trackChanges);
        void CreateSubCategory(SubCategory subCategory);
        void UpdateSubCategory(SubCategory subCategory);
        void DeleteSubCategory(SubCategory subCategory);
    }

}
