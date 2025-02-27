using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/pharmacy-requests")]
    [ApiController]
    [Authorize]
    public class PharmacyRequestController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyRequestController(IServiceManager service) => _service = service;

        [HttpPost("submit")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> SubmitRequest([FromForm] PharmacyRequestCreateDto pharmacyRequestCreateDto)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
                throw new UserNameBadRequestException();
            await _service.PharmacyRequestService.SubmitRequestAsync(userName, pharmacyRequestCreateDto, trackChanges: true);
            return Ok();
        }
        [Authorize(Roles ="Admin")]
        [HttpPatch("{requestId}/approve")]
        public async Task<IActionResult> ApproveRequest(ulong requestId)
        {
            await _service.PharmacyRequestService.ApproveRequestAsync(requestId, trackChanges: false);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{requestId}/reject")]
        public async Task<IActionResult> RejectRequest(ulong requestId)
        {
            await _service.PharmacyRequestService.RejectRequestAsync(requestId, trackChanges: false);
            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendiRequests([FromQuery] PharmacyRequestParameters pharmacyRequestParameters)
        {
            var (pharmacyRequests, metaData) = await _service.PharmacyRequestService.GetPendingRequestsAsync(pharmacyRequestParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(pharmacyRequests);
        }
    }
    
}
