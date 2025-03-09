using Entities.Models;
namespace Contracts
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(bool trackChanges);
        Task<SubCategory> GetSubCategoryByIdAsync(Guid categoryId, Guid subCategoryId, bool trackChanges);
        Task<SubCategory> GetSubCategoryByIdAsync(Guid subCategoryId, bool trackChanges);
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(Guid categoryId, bool trackChanges);
        void CreateSubCategory(SubCategory subCategory);
        void UpdateSubCategory(SubCategory subCategory);
        void DeleteSubCategory(SubCategory subCategory);
    }
}
