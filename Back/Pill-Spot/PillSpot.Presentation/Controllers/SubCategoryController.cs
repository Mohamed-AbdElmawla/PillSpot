using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/categories/{categoryId}/subcategories")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SubCategoryController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(Guid categoryId)
        {
            var subCategories = await _service.SubCategoryService.GetSubCategoriesByCategoryIdAsync(categoryId, trackChanges: false);
            return Ok(subCategories);
        }

        [HttpGet("{subCategoryId:Guid}")]
        public async Task<IActionResult> GetSubCategoryById(Guid categoryId, Guid subCategoryId)
        {
            var subCategory = await _service.SubCategoryService.GetSubCategoryByIdAsync(categoryId, subCategoryId, trackChanges: false);
            return Ok(subCategory);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateSubCategory(Guid categoryId, [FromBody] SubCategoryForCreateDto subCategoryDto)
        {
            await _service.SubCategoryService.CreateSubCategory(categoryId, subCategoryDto, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{subCategoryId:Guid}")]
        //[Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateSubCategory(Guid categoryId, Guid subCategoryId, [FromBody] SubCategoryForUpdateDto subCategoryDto)
        {
            await _service.SubCategoryService.UpdateSubCategory(categoryId, subCategoryId, subCategoryDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{subCategoryId:Guid}")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSubCategory(Guid categoryId, Guid subCategoryId)
        {
            await _service.SubCategoryService.DeleteSubCategory(categoryId, subCategoryId, trackChanges: true);
            return NoContent();
        }
    }
}
