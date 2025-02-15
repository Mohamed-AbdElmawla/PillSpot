using Microsoft.AspNetCore.Mvc;
using PharmacyLocator.Presentation.ActionFilters;
using PharmacyLocator.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/pharmacies")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmaciesController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetPharmacies([FromQuery] PharmaciesParameters pharmaciesparameters)
        {
            var pagedResult = await _service.PharmacyService.GetAllPharmaciesAsync(false, pharmaciesparameters);

            Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.Pharmacies);
        }
        [HttpGet("{id:guid}", Name = "PharmacyById")]
        public async Task<IActionResult> GetPharmacy(string Id)
        {
            var pharmacy = await _service.PharmacyService.GetPharmacyAsync(Id, true);
            return Ok(pharmacy);
        }
        [HttpPost]
        [ValidationFilterAttribute]
        public async Task<IActionResult> CreatePharmacy([FromBody] PharmacyForCreationDto pharmacy)
        {
            if (pharmacy is null)
            {
                return BadRequest("PharmacyForCreationDto object is null");
            }
            var createdPharmacy = await _service.PharmacyService.CreatePharmacyAsync(pharmacy);
            return CreatedAtRoute("PharmacyById", new { Id = createdPharmacy.PharmacyId }, createdPharmacy);
        }

        [HttpGet("collection/({ids})", Name = "PharmacyCollection")]
        public async Task<IActionResult> GetPharmacyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<string> ids)
        {
            var pharmacies = await _service.PharmacyService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(pharmacies);
        }

        [HttpPost("collection")]
        [ValidationFilterAttribute]
        public async Task<IActionResult> CreatePharmacyCollection([FromBody] IEnumerable<PharmacyForCreationDto> pharmacyCollection)
        {
            var result = await _service.PharmacyService.CreatePharmacyCollectionAsync(pharmacyCollection);
            return CreatedAtRoute("PharmacyCollection", new { result.ids }, result.pharmacies);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePharmacy(string Id)
        {
            await _service.PharmacyService.DeletePharmacy(Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePharmacy(string id, [FromBody] PharmacyForUpdateDto pharmacy)
        {
            if (pharmacy is null)
                return BadRequest("PharmacyForUpdateDto object is null");

            await _service.PharmacyService.UpdatePharmacy(id, pharmacy, trackChanges: true);

            return NoContent();
        }
    }
}
