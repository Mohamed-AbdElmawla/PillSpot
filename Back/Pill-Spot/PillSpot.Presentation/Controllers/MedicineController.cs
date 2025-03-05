using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/medicines")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MedicineController(IServiceManager service) => _service = service;

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetMedicine(long id)
        {
            var medicine = await _service.MedicineService.GetMedicineAsync((ulong)id, trackChanges: false);
            return Ok(medicine);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMedicine([FromBody] MedicineForCreationDto medicineDto)
        {
            var createdMedicine = await _service.MedicineService.CreateMedicineAsync(medicineDto);
            return CreatedAtAction(nameof(GetMedicine), new { id = createdMedicine.ProductId }, createdMedicine);
        }

        [HttpDelete("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMedicine(long id)
        {
            await _service.MedicineService.DeleteMedicine((ulong)id, trackChanges: true);
            return NoContent();
        }
    }
}