using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;
using System.Threading.Tasks;

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

        [HttpGet("pharmacies/{pharmacyId:Guid}/products/{productId:Guid}")]
        public async Task<IActionResult> GetPharmacyProduct(Guid pharmacyId, Guid productId)
        {
            var pharmacyProduct = await _service.PharmacyProductService.GetPharmacyProductAsync(productId, pharmacyId, trackChanges: false);
            return Ok(pharmacyProduct);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePharmacyProduct([FromBody] PharmacyProductForCreationDto pharmacyProductDto)
        {
            var createdPharmacyProduct = await _service.PharmacyProductService.CreatePharmacyProductAsync(pharmacyProductDto);
            return CreatedAtAction(nameof(GetPharmacyProduct), new { pharmacyId = createdPharmacyProduct.PharmacyId, productId = createdPharmacyProduct.ProductId }, createdPharmacyProduct);
        }

        [HttpDelete("pharmacies/{pharmacyId:Guid}/products/{productId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePharmacyProduct(Guid pharmacyId, Guid productId)
        {
            await _service.PharmacyProductService.DeletePharmacyProductAsync(productId, pharmacyId, trackChanges: true);
            return NoContent();
        }

        [HttpGet("pharmacies/{pharmacyId:Guid}/products/{productId:Guid}/batch")]
        public async Task<IActionResult> GetBatchForPharmacyProduct(Guid pharmacyId, Guid productId)
        {
            var batch = await _service.PharmacyProductService.GetBatchForPharmacyProductAsync(productId, pharmacyId, trackChanges: false);
            return Ok(batch);
        }
    }
}