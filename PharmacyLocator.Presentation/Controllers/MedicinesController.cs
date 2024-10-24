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
        public IActionResult GetMedicinesForPharmacy(int pharmacyId)
        {
            var medicines = _service.PharmacyMedicineService.GetMedicines(pharmacyId,false);
            return Ok(medicines);
        }

        [HttpGet("{medicineId:int}", Name = "GetMedicineForPharmacy")]
        public IActionResult GetMedicineForPharmacy(int pharmacyId, int medicineId)
        {
            var medicine = _service.PharmacyMedicineService.GetMedicine(pharmacyId, medicineId, false);
            return Ok(medicine);
        }

        [HttpPost]
        public IActionResult CreatePharmacyMedicine(int pharmacyId, [FromBody] PharmacyMedicineForCreationDto pharmacyMedicine)
        {
            if (pharmacyMedicine is null)
                return BadRequest("PharmacyMedicineForCreationDto object is null");

            var pharmacyMedicineToReturn = _service.PharmacyMedicineService.CreatePharmacyMedicine(pharmacyId, pharmacyMedicine, trackChanges: false);

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
