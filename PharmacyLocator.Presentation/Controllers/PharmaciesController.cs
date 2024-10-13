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
        public IActionResult GetPharmacies()
        {
            var pharmacies = _service.PharmacyService.GetAllPharmacies(true);
            return Ok(pharmacies);
        }
        [HttpGet("{id:int}",Name ="PharmacyById")]
        public IActionResult GetPharmacy(int Id)
        {
            var pharmacy = _service.PharmacyService.GetPharmacy(Id, true);
            return Ok(pharmacy);
        }
        [HttpPost]
        public IActionResult CreatePharmacy([FromBody] PharmacyForCreationDto pharmacy)
        {
            if( pharmacy is null)
            {
                return BadRequest("PharmacyForCreationDto object is null");
            }
            var createdPharmacy = _service.PharmacyService.CreatePharmacy(pharmacy);
            return CreatedAtRoute("PharmacyById", new {Id = createdPharmacy.Id},createdPharmacy);
        }
        [HttpGet("collection/({ids})",Name = "PharmacyCollection")]
        public IActionResult GetPharmacyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var pharmacies = _service.PharmacyService.GetByIds(ids,trackChanges: false);
            return Ok(pharmacies);
        }

        [HttpPost("collection")]
        public IActionResult CreatePharmacyCollection([FromBody] IEnumerable<PharmacyForCreationDto> pharmacyCollection)
        {
            var result = _service.PharmacyService.CreatePharmacyCollection(pharmacyCollection);
            return CreatedAtRoute("PharmacyCollection", new { result.ids }, result.pharmacies);
        }
    }
}
