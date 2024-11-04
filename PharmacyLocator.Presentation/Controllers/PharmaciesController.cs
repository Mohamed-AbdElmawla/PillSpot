using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyLocator.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/pharmacies")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmaciesController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetPharmacies()
        {
            var pharmacies = await _service.PharmacyService.GetAllPharmaciesAsync(true);
            return Ok(pharmacies);
        }
        [HttpGet("{id:int}",Name ="PharmacyById")]
        public async Task<IActionResult> GetPharmacy(int Id)
        {
            var pharmacy = await _service.PharmacyService.GetPharmacyAsync(Id, true);
            return Ok(pharmacy);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePharmacy([FromBody] PharmacyForCreationDto pharmacy)
        {
            if( pharmacy is null)
            {
                return BadRequest("PharmacyForCreationDto object is null");
            }
            var createdPharmacy = await _service.PharmacyService.CreatePharmacyAsync(pharmacy);
            return CreatedAtRoute("PharmacyById", new {Id = createdPharmacy.Id},createdPharmacy);
        }

        [HttpGet("collection/({ids})",Name = "PharmacyCollection")]
        public async Task<IActionResult> GetPharmacyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var pharmacies = await _service.PharmacyService.GetByIdsAsync(ids,trackChanges: false);
            return Ok(pharmacies);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreatePharmacyCollection([FromBody] IEnumerable<PharmacyForCreationDto> pharmacyCollection)
        {
            var result = await _service.PharmacyService.CreatePharmacyCollectionAsync(pharmacyCollection);
            return CreatedAtRoute("PharmacyCollection", new { result.ids }, result.pharmacies);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePharmacy(int Id)
        {
            _service.PharmacyService.DeletePharmacy(Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdatePharmacy(int id, [FromBody] PharmacyForUpdateDto pharmacy)
        {
            if (pharmacy is null)
                return BadRequest("PharmacyForUpdateDto object is null");

            _service.PharmacyService.UpdatePharmacy(id, pharmacy, trackChanges: true);

            return NoContent();
        }
    }
}
