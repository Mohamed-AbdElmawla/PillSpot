using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync(bool trackChanges);
        Task<SubCategoryDto> GetSubCategoryByIdAsync(Guid categoryId, Guid subCategoryId, bool trackChanges);
        Task<IEnumerable<SubCategoryDto>> GetSubCategoriesByCategoryIdAsync(Guid categoryId, bool trackChanges);
        Task CreateSubCategory(Guid categoryId, SubCategoryForCreateDto subCategoryForCreateDto, bool trackChanges);
        Task UpdateSubCategory(Guid categoryId, Guid subCategoryId, SubCategoryForUpdateDto subCategoryForUpdateDto, bool trackChanges);
        Task DeleteSubCategory(Guid categoryId, Guid subCategoryId, bool trackChanges);
    }
}
