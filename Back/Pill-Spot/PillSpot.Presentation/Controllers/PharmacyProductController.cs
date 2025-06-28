using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/pharmacyproducts")]
    [ApiController]
    public class PharmacyProductController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyProductController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllPharmacyProducts([FromQuery] PharmacyProductParameters pharmacyProductParameters)
        {
            var pagedResult = await _service.PharmacyProductService.GetAllPharmacyProductsAsync(pharmacyProductParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacyProducts);
        }

        
        [HttpGet("pharmacy/{pharmacyId:Guid}/product/{productId:Guid}")]
        public async Task<IActionResult> GetPharmacyProduct(Guid pharmacyId, Guid productId)
        {
            var pharmacyProduct = await _service.PharmacyProductService.GetPharmacyProductAsync(productId, pharmacyId, trackChanges: false);
            return Ok(pharmacyProduct);
        }

        
        [HttpGet("pharmacy/{pharmacyId:Guid}/products")]
        public async Task<IActionResult> GetPharmacyProducts(Guid pharmacyId, [FromQuery] PharmacyProductParameters pharmacyProductParameters)
        {
            var pagedResult = await _service.PharmacyProductService.GetPharmacyProductsByPharmacyIdAsync(pharmacyId, pharmacyProductParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.pharmacyProducts);
        }

        
        [HttpGet("product/{productId:Guid}/pharmacies")]
        public async Task<IActionResult> GetProductPharmacies(Guid productId, [FromQuery] PharmacyProductParameters pharmacyProductParameters)
        {
            var pagedResult = await _service.PharmacyProductService.GetPharmacyProductsByProductIdAsync(productId, pharmacyProductParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.pharmacyProducts);
        }
        

        [HttpPost]
        [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreatePharmacyProduct([FromBody] PharmacyProductForCreationDto pharmacyProductDto)
        {
            var createdPharmacyProduct = await _service.PharmacyProductService.CreatePharmacyProductAsync(pharmacyProductDto, trackChanges: true);
            return CreatedAtAction(nameof(GetPharmacyProduct), new { pharmacyId = createdPharmacyProduct.PharmacyDto.PharmacyId, productId = createdPharmacyProduct.ProductDto.ProductId }, createdPharmacyProduct);
        }


        [HttpDelete("pharmacy/{pharmacyId:Guid}/product/{productId:Guid}")]
        [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeletePharmacyProduct(Guid pharmacyId, Guid productId)
        {
            await _service.PharmacyProductService.DeletePharmacyProductAsync(productId, pharmacyId, trackChanges: true);
            return NoContent();
        }

        /*[HttpGet("pharmacies/{pharmacyId:Guid}/products/{productId:Guid}/batch")]
        public async Task<IActionResult> GetBatchForPharmacyProduct(Guid pharmacyId, Guid productId)
        {
            var batch = await _service.PharmacyProductService.GetBatchForPharmacyProductAsync(productId, pharmacyId, trackChanges: false);
            return Ok(batch);
        }*/
    }
}