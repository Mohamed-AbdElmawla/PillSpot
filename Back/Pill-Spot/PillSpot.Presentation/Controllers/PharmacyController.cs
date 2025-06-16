using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/pharmacies")]
    [ApiController]
    [Authorize]
    public class PharmacyController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyController(IServiceManager service) => _service = service;

        [HttpGet("AllPharmacies")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("GetAllPharmacies")]
        public async Task<IActionResult> GetAllPharmacies([FromQuery] PharmaciesParameters pharmaciesParameters)
        {
            var pagedResult = await _service.PharmacyService.GetAllPharmaciesAsync(pharmaciesParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacies);
        }

        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("GetPharmacy")]
        public async Task<IActionResult> GetPharmacy(Guid id)
        {
            var pharmacy = await _service.PharmacyService.GetPharmacyAsync(id, trackChanges: false);
            return Ok(pharmacy);
        }

        [HttpPost("cerate")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [PermissionAuthorize("CreatePharmacy")]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreatePharmacy([FromBody] PharmacyForCreationDto pharmacyDto)
        {
            var createdPharmacy = await _service.PharmacyService.CreatePharmacyAsync(pharmacyDto);
            return CreatedAtAction(nameof(GetPharmacy), new { id = createdPharmacy.PharmacyId }, createdPharmacy);
        }

        [HttpPost("create-collection")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [PermissionAuthorize("CreatePharmacyCollection")]
        [ValidateCsrfToken]
        public async Task<IActionResult> CreatePharmacyCollection([FromBody] IEnumerable<PharmacyForCreationDto> pharmacies)
        {
            var (createdPharmacies, ids) = await _service.PharmacyService.CreatePharmacyCollectionAsync(pharmacies);

            return CreatedAtAction(nameof(GetByIds), new { ids }, createdPharmacies);
        }

        [HttpGet("collection/{ids}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("GetPharmaciesByIds")]
        public async Task<IActionResult> GetByIds([FromRoute] string ids, [FromQuery] PharmaciesParameters parameters)
        {
            var idArray = ids.Split(',').Select(Guid.Parse);
            var pagedResult = await _service.PharmacyService.GetByIdsAsync(idArray, parameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacies);
        }

        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [PermissionAuthorize("UpdatePharmacy")]
        [ValidateCsrfToken]
        public async Task<IActionResult> UpdatePharmacy(Guid id, [FromForm] PharmacyForUpdateDto pharmacyDto)
        {
            await _service.PharmacyService.UpdatePharmacy(id, pharmacyDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("DeletePharmacy")]
        [ValidateCsrfToken]
        public async Task<IActionResult> DeletePharmacy(Guid id)
        {
            await _service.PharmacyService.DeletePharmacy(id, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{id:Guid}/suspend")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("SuspendPharmacy")]
        [ValidateCsrfToken]
        public async Task<IActionResult> SuspendPharmacyAsync(Guid id)
        {
            await _service.PharmacyService.SuspendPharmacyAsync(id, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{id:Guid}/activate")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("ActivatePharmacy")]
        [ValidateCsrfToken]
        public async Task<IActionResult> ActivatePharmacyAsync(Guid id)
        {
            await _service.PharmacyService.ActivatePharmacyAsync(id, trackChanges: true);
            return NoContent();
        }

    }
}
