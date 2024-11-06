using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/medicines")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MedicineController(IServiceManager service) => _service = service;

        [HttpGet("{id:int}", Name = "MedicineById")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var medicine = await _service.MedicineService.GetMedicineAsync(id,true);
            return Ok(medicine);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine([FromBody] MedicineForCreationDto medicine)
        {
            if (medicine is null)
            {
                return BadRequest("MedicineForCreationDto object is null");
            }
            var createdMedicine = await _service.MedicineService.CreateMedicineAsync(medicine);
            return CreatedAtRoute("MedicineById", new { Id = createdMedicine.MedicineId }, createdMedicine);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMedicine(int Id)
        {
           await _service.MedicineService.DeleteMedicine(Id, trackChanges: false);
            return NoContent();
        }
    }
}
