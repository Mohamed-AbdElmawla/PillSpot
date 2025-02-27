using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoryController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _service.CategoryService.GetCategoryByIdAsync(id, trackChanges: false);
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreateDto categoryForCreateDto)
        {
            await _service.CategoryService.CreateCategoryAsync(categoryForCreateDto);
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryForUpdateDto categoryForUpdateDto)
        {
            await _service.CategoryService.UpdateCategory(id, categoryForUpdateDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _service.CategoryService.DeleteCategory(id, trackChanges:true);
            return NoContent();
        }
    }
}
