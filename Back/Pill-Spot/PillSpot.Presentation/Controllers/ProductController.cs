using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProductController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.ProductService.GetAllProductsAsync(trackChanges: false);
            return Ok(products);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            var product = await _service.ProductService.GetProductAsync((ulong)id, trackChanges: false);
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productDto)
        {
            var createdProduct = await _service.ProductService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.ProductId }, createdProduct);
        }

        /*[HttpPut("{id:long}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProduct(long id, [FromBody] ProductForUpdateDto productDto)
        {
            await _service.ProductService.UpdateProduct((ulong)id, productDto, trackChanges: true);
            return NoContent();
        }*/

        [HttpDelete("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            await _service.ProductService.DeleteProduct((ulong)id, trackChanges: true);
            return NoContent();
        }
    }
}