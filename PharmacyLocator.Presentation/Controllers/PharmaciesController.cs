using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
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

        public IActionResult GetPharmacies()
        {
            var pharmacies = _service.PharmacyService.GetAllPharmacies(false);
            return Ok(pharmacies);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetPharmacy(int Id)
        {
            var pharmacy = _service.PharmacyService.GetPharmacy(Id, true);
            return Ok(pharmacy);
        }
    }
}
