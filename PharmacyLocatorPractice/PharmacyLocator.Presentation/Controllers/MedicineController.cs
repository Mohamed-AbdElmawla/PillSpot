using Microsoft.AspNetCore.Mvc;
using PharmacyLocator.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/medicines")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MedicineController(IServiceManager service) => _service = service;

        [HttpGet("{id:guid}", Name = "MedicineById")]
        public async Task<IActionResult> GetMedicine(string id)
        {
            var medicine = await _service.MedicineService.GetMedicineAsync(id, true);
            return Ok(medicine);
        }

        [HttpPost]
        [ValidationFilterAttribute]
        public async Task<IActionResult> CreateMedicine([FromBody] MedicineForCreationDto medicine)
        {
            if (medicine is null)
                return BadRequest("MedicineForCreationDto object is null");

            var createdMedicine = await _service.MedicineService.CreateMedicineAsync(medicine);
            return CreatedAtRoute("MedicineById", new { Id = createdMedicine.MedicineId }, createdMedicine);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMedicine(string Id)
        {
            await _service.MedicineService.DeleteMedicine(Id, trackChanges: false);
            return NoContent();
        }
    }
}
