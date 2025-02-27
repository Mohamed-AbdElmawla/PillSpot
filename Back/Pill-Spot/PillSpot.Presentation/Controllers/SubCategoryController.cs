using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/categories/{categoryId}/subcategories")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public SubCategoryController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCategories = await _service.SubCategoryService.GetSubCategoriesByCategoryIdAsync(categoryId, trackChanges: false);
            return Ok(subCategories);
        }

        [HttpGet("{subCategoryId:int}")]
        public async Task<IActionResult> GetSubCategoryById(int categoryId, int subCategoryId)
        {
            var subCategory = await _service.SubCategoryService.GetSubCategoryByIdAsync(categoryId, subCategoryId, trackChanges: false);
            return Ok(subCategory);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateSubCategory(int categoryId, [FromBody] SubCategoryForCreateDto subCategoryDto)
        {
            await _service.SubCategoryService.CreateSubCategory(categoryId, subCategoryDto, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{subCategoryId:int}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateSubCategory(int categoryId, int subCategoryId, [FromBody] SubCategoryForUpdateDto subCategoryDto)
        {
            await _service.SubCategoryService.UpdateSubCategory(categoryId, subCategoryId, subCategoryDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{subCategoryId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSubCategory(int categoryId, int subCategoryId)
        {
            await _service.SubCategoryService.DeleteSubCategory(categoryId, subCategoryId, trackChanges: true);
            return NoContent();
        }
    }
}
