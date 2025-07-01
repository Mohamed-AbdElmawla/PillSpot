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
        public async Task<IActionResult> GetAllPharmacies([FromQuery] PharmaciesParameters pharmaciesParameters)
        {
            var pagedResult = await _service.PharmacyService.GetAllPharmaciesAsync(pharmaciesParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacies);
        }

        [HttpGet("{pharmacyId:Guid}")]        
        public async Task<IActionResult> GetPharmacy(Guid pharmacyId)
        {
            var pharmacy = await _service.PharmacyService.GetPharmacyAsync(pharmacyId, trackChanges: false);
            return Ok(pharmacy);
        }
        /*
        //[HttpPost("cerate")]
        //[ValidateCsrfToken]
        //[Authorize(Roles = "SuperAdmin,Admin")]
        //[PermissionAuthorize("CreatePharmacy")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //public async Task<IActionResult> CreatePharmacy([FromBody] PharmacyForCreationDto pharmacyDto)
        //{
        //    var createdPharmacy = await _service.PharmacyService.CreatePharmacyAsync(pharmacyDto);
        //    return CreatedAtAction(nameof(GetPharmacy), new { id = createdPharmacy.PharmacyId }, createdPharmacy);
        //}

        //[HttpPost("create-collection")]
        //[Authorize(Roles = "SuperAdmin,Admin")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //[PermissionAuthorize("CreatePharmacyCollection")]
        //[ValidateCsrfToken]
        //public async Task<IActionResult> CreatePharmacyCollection([FromBody] IEnumerable<PharmacyForCreationDto> pharmacies)
        //{
        //    var (createdPharmacies, ids) = await _service.PharmacyService.CreatePharmacyCollectionAsync(pharmacies);

        //    return CreatedAtAction(nameof(GetByIds), new { ids }, createdPharmacies);
        //}

        //[HttpGet("collection/{ids}")]
        //[Authorize(Roles = "SuperAdmin,Admin")]
        //[PermissionAuthorize("GetPharmaciesByIds")]
        //public async Task<IActionResult> GetByIds([FromRoute] string ids, [FromQuery] PharmaciesParameters parameters)
        //{
        //    var idArray = ids.Split(',').Select(Guid.Parse);
        //    var pagedResult = await _service.PharmacyService.GetByIdsAsync(idArray, parameters, trackChanges: false);

        //    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        //    return Ok(pagedResult.pharmacies);
        //}
        */

        [HttpPut("{pharmacyId:Guid}")]
        [ValidateCsrfToken]
        [PharmacyRoleAuthorize("PharmacyOwner")]
        [PermissionAuthorize("PharmacyManagement")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePharmacy(Guid pharmacyId, [FromForm] PharmacyForUpdateDto pharmacyDto)
        {
            await _service.PharmacyService.UpdatePharmacy(pharmacyId, pharmacyDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{pharmacyId:Guid}")]
        [ValidateCsrfToken]
        [PharmacyRoleAuthorize("PharmacyOwner")]
        [PermissionAuthorize("PharmacyManagement")]
        public async Task<IActionResult> DeletePharmacy(Guid pharmacyId)
        {
            await _service.PharmacyService.DeletePharmacy(pharmacyId, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{pharmacyId:Guid}/suspend")]
        [ValidateCsrfToken]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("PharmacyManagement")]
        public async Task<IActionResult> SuspendPharmacyAsync(Guid pharmacyId)
        {
            await _service.PharmacyService.SuspendPharmacyAsync(pharmacyId, trackChanges: true);
            return NoContent();
        }

        [HttpPut("{pharmacyId:Guid}/activate")]
        [ValidateCsrfToken]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [PermissionAuthorize("ActivatePharmacy")]
        public async Task<IActionResult> ActivatePharmacyAsync(Guid pharmacyId)
        {
            await _service.PharmacyService.ActivatePharmacyAsync(pharmacyId, trackChanges: true);
            return NoContent();
        }

    }
}
