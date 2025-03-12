using Entities.Models;
using Shared.RequestFeatures;
namespace Contracts
{
    public interface ISubCategoryRepository
    {
        Task<PagedList<SubCategory>> GetAllSubCategoriesAsync(SubCategoriesRequestParameters subCategoriesRequestParameters, bool trackChanges);
        Task<SubCategory> GetSubCategoryByIdAsync(Guid categoryId, Guid subCategoryId, bool trackChanges);
        Task<SubCategory> GetSubCategoryByIdAsync(Guid subCategoryId, bool trackChanges);
        Task<PagedList<SubCategory>> GetSubCategoriesByCategoryIdAsync(Guid categoryId, SubCategoriesRequestParameters subCategoriesRequestParameters, bool trackChanges);
        void CreateSubCategory(SubCategory subCategory);
        void UpdateSubCategory(SubCategory subCategory);
        void DeleteSubCategory(SubCategory subCategory);
    }
}
