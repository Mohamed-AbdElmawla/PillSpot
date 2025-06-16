using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;


namespace PillSpot.Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProductController(IServiceManager service) => _service = service;

        [HttpGet]
        [RateLimit("SearchPolicy")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductRequestParameters ProductRequestParameters)
        {
            var pagedResult = await _service.ProductService.GetAllProductsAsync(ProductRequestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.products);
        }

        [HttpGet("{id:Guid}")]
        [RateLimit("SearchPolicy")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _service.ProductService.GetProductAsync(id, trackChanges: false);
            return Ok(product);
        }

        [HttpPost]
        [RateLimit("UploadPolicy")]
        // [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreateProduct([FromForm] ProductForCreationDto productDto)
        {
            var createdProduct = await _service.ProductService.CreateProductAsync(productDto, trackChanges: true);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPatch("{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ValidateCsrfToken]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromForm] ProductForUpdateDto productForUpdateDto)
        {
            await _service.ProductService.UpdateProductAsync(id, productForUpdateDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _service.ProductService.DeleteProductAsync(id, trackChanges: true);
            return NoContent();
        }
    }
}