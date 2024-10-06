using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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
        [HttpGet("{medicineId:int}")]
        public IActionResult GetMedicineForPharmacy(int pharmacyId, int medicineId)
        {
            var medicine = _service.PharmacyMedicineService.GetMedicine(pharmacyId, medicineId, false);
            return Ok(medicine);
        }
    }
}
