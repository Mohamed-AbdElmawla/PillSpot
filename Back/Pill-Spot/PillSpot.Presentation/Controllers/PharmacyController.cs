using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/pharmacies")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllPharmacies([FromQuery] PharmaciesParameters pharmaciesParameters)
        {
            var pagedResult = await _service.PharmacyService.GetAllPharmaciesAsync(pharmaciesParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacies);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetPharmacy(long id)
        {
            var pharmacy = await _service.PharmacyService.GetPharmacyAsync((ulong)id, trackChanges: false);
            return Ok(pharmacy);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePharmacy([FromBody] PharmacyForCreationDto pharmacyDto)
        {
            var createdPharmacy = await _service.PharmacyService.CreatePharmacyAsync(pharmacyDto);
            return CreatedAtAction(nameof(GetPharmacy), new { id = createdPharmacy.PharmacyID }, createdPharmacy);
        }
        [HttpPost("collection")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePharmacyCollection([FromBody] IEnumerable<PharmacyForCreationDto> pharmacies)
        {
            var (createdPharmacies, ids) = await _service.PharmacyService.CreatePharmacyCollectionAsync(pharmacies);

            return CreatedAtAction(nameof(GetByIds), new { ids }, createdPharmacies);
        }

        [HttpGet("collection/{ids}")]
        public async Task<IActionResult> GetByIds([FromRoute] string ids, [FromQuery] PharmaciesParameters parameters)
        {
            var idArray = ids.Split(',').Select(ulong.Parse);
            var pagedResult = await _service.PharmacyService.GetByIdsAsync(idArray, parameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.pharmacies);
        }

        [HttpPut("{id:long}")]
        [Authorize(Roles ="Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePharmacy(long id, [FromBody] PharmacyForUpdateDto pharmacyDto)
        {
            await _service.PharmacyService.UpdatePharmacy((ulong)id, pharmacyDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePharmacy(long id)
        {
            await _service.PharmacyService.DeletePharmacy((ulong)id, trackChanges: true);
            return NoContent();
        }

    }
}
