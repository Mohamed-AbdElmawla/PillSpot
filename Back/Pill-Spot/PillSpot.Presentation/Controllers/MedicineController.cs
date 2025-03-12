using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/medicines")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MedicineController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllMedicines([FromQuery] MedicinesRequestParameters medicinesRequestParameters)
        {
            var pagedResult = await _service.MedicineService.GetAllMedicinesAsync(medicinesRequestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.medicines);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetMedicine(Guid id)
        {
            var medicine = await _service.MedicineService.GetMedicineAsync(id, trackChanges: false);
            return Ok(medicine);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMedicine([FromForm] MedicineForCreationDto medicineDto)
        {
            var createdMedicine = await _service.MedicineService.CreateMedicineAsync(medicineDto, trackChanges: true);
            return CreatedAtAction(nameof(GetMedicine), new { id = createdMedicine.ProductId }, createdMedicine);
        }

        [HttpPatch("{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMedicine(Guid id, [FromForm] MedicineForUpdateDto medicineForUpdateDto)
        {
            await _service.MedicineService.UpdateMedicineAsync(id, medicineForUpdateDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMedicine(Guid id)
        {
            await _service.MedicineService.DeleteMedicineAsync(id, trackChanges: true);
            return NoContent();
        }
    }
}