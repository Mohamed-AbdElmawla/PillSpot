using Microsoft.AspNetCore.Mvc;
using PharmacyLocator.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/pharmacies/{pharmacyId}/medicines")]
    public class PharmacyMedicineController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyMedicineController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetMedicinesForPharmacy(string pharmacyId, [FromQuery] PharmacyMedicineParameters pharmacyMedicineParameters)
        {
            var pagedResult = await _service.PharmacyMedicineService.GetMedicinesAsync(pharmacyId, pharmacyMedicineParameters, false);

            Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.Medicines);
        }

        [HttpGet("{medicineId:guid}", Name = "GetMedicineForPharmacy")]
        public async Task<IActionResult> GetMedicineForPharmacy(string pharmacyId, string medicineId)
        {
            var medicine = await _service.PharmacyMedicineService.GetMedicineAsync(pharmacyId, medicineId, false);
            return Ok(medicine);
        }

        [HttpPost]
        [ValidationFilterAttribute]
        public async Task<IActionResult> CreatePharmacyMedicine(string pharmacyId, [FromBody] PharmacyMedicineForCreationDto pharmacyMedicine)
        {
            if (pharmacyMedicine is null)
                return BadRequest("PharmacyMedicineForCreationDto object is null");

            var pharmacyMedicineToReturn = await _service.PharmacyMedicineService.CreatePharmacyMedicineAsync(pharmacyId, pharmacyMedicine, trackChanges: false);

            return CreatedAtRoute("GetMedicineForPharmacy", new { pharmacyId, medicineId = pharmacyMedicineToReturn.MedicineId }, pharmacyMedicineToReturn);
        }
        [HttpDelete("{medicineId:guid}")]
        public IActionResult DeletePharmacyMedicine(string pharmacyId, string medicineId)
        {
            _service.PharmacyMedicineService.DeletePharmacyMedicine(pharmacyId, medicineId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{medicineId:guid}")]
        public async Task<IActionResult> UpdatePharmaycMedicineForPharmacy(string pharmacyId, string medicineId,
        [FromBody] PharmacyMedicineForUpdateDto pharmaycMedicine)
        {
            if (pharmaycMedicine is null)
                return BadRequest("PharmacyMedicineForUpdateDto object is null");

            await _service.PharmacyMedicineService.UpdatePharmacyMedicine(pharmacyId, medicineId, pharmaycMedicine,
            phTrackChanges: false, phMedTrackChanges: true);
            return NoContent();
        }
    }
}
