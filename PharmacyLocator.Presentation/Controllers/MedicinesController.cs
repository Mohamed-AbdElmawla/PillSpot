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
    [Route("api/pharmacies/{pharmacyId}/medicines")]
    public class MedicinesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public MedicinesController(IServiceManager service)=> _service = service;
        public async Task<IActionResult> GetMedicinesForPharmacy(int pharmacyId)
        {
            var medicines = await _service.PharmacyMedicineService.GetMedicinesAsync(pharmacyId,false);
            return Ok(medicines);
        }
        [HttpGet("{medicineId:int}", Name = "GetMedicineForPharmacy")]
        public async Task<IActionResult> GetMedicineForPharmacy(int pharmacyId, int medicineId)
        {
            var medicine = await _service.PharmacyMedicineService.GetMedicineAsync(pharmacyId, medicineId, false);
            return Ok(medicine);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePharmacyMedicine(int pharmacyId, [FromBody] PharmacyMedicineForCreationDto pharmacyMedicine)
        {
            if (pharmacyMedicine is null)
                return BadRequest("PharmacyMedicineForCreationDto object is null");

            var pharmacyMedicineToReturn = await _service.PharmacyMedicineService.CreatePharmacyMedicineAsync(pharmacyId, pharmacyMedicine, trackChanges: false);

            return CreatedAtRoute("GetMedicineForPharmacy", new { pharmacyId, medicineId = pharmacyMedicineToReturn.MedicineId }, pharmacyMedicineToReturn);
        }
        [HttpDelete("{medicineId:int}")]
        public IActionResult DeletePharmacyMedicine(int pharmacyId, int medicineId)
        {
            _service.PharmacyMedicineService.DeletePharmacyMedicine(pharmacyId, medicineId, trackChanges: false);
            return NoContent();
        }
    }
}
