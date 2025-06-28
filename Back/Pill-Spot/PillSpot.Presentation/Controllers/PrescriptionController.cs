using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Security.Claims;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PrescriptionController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions([FromQuery] PrescriptionParameters prescriptionParameters)
        {
            var (prescriptions, metaData) = await _service.PrescriptionService.GetAllPrescriptionsAsync(prescriptionParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(prescriptions);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetPrescriptionsByUser([FromQuery] PrescriptionParameters prescriptionParameters)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var prescriptions = await _service.PrescriptionService.GetPrescriptionsByUserAsync(userId, prescriptionParameters, false);
            return Ok(prescriptions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPrescription(Guid id)
        {
            var prescription = await _service.PrescriptionService.GetPrescriptionByIdAsync(id, false);
            return Ok(prescription);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromForm] PrescriptionForCreationDto form)
        {
            var createdPrescription = await _service.PrescriptionService.CreatePrescriptionAsync(form);
            return CreatedAtAction(nameof(GetPrescription), new { id = createdPrescription.PrescriptionId }, createdPrescription);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePrescription(Guid id, [FromForm] PrescriptionForUpdateDto prescriptionDto)
        {
            await _service.PrescriptionService.UpdatePrescriptionAsync(id, prescriptionDto, true);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePrescription(Guid id)
        {
            await _service.PrescriptionService.DeletePrescriptionAsync(id, true);
            return NoContent();
        }
    }
}