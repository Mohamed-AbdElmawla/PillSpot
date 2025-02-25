using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/pharmacies")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyController(IServiceManager service) => _service = service;

    }
}
