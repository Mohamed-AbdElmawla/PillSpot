using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoryController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery]CategoriesRequestParameters categoriesRequestParameters)
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(categoriesRequestParameters, trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _service.CategoryService.GetCategoryByIdAsync(id, trackChanges: false);
            return Ok(category);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreateDto categoryForCreateDto)
        {
            await _service.CategoryService.CreateCategoryAsync(categoryForCreateDto);
            return StatusCode(201);
        }

        [HttpPut("{id:Guid}")]
       // [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto categoryForUpdateDto)
        {
            await _service.CategoryService.UpdateCategory(id, categoryForUpdateDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _service.CategoryService.DeleteCategory(id, trackChanges:true);
            return NoContent();
        }
    }
}
