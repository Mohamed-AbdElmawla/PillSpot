using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> SubmitRequest([FromForm] PharmacyRequestCreateDto pharmacyRequestCreateDto)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
                throw new UserNameBadRequestException();
            await _service.PharmacyRequestService.SubmitRequestAsync(userName, pharmacyRequestCreateDto, trackChanges: true);
            return Ok();
        }
        [HttpPatch("{requestId}/approve")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> ApproveRequest(Guid requestId)
        {
            await _service.PharmacyRequestService.ApproveRequestAsync(requestId, trackChanges: true);
            return NoContent();
        }
        [HttpPatch("{requestId}/reject")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> RejectRequest(Guid requestId)
        {
            await _service.PharmacyRequestService.RejectRequestAsync(requestId, trackChanges: true);
            return NoContent();
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetRequests([FromQuery] PharmacyRequestParameters pharmacyRequestParameters)
        {
            var (pharmacyRequests, metaData) = await _service.PharmacyRequestService.GetRequestsAsync(pharmacyRequestParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(pharmacyRequests);
        }
    }
    
}
