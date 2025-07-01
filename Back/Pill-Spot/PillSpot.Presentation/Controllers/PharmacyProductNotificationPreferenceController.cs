using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PillSpot.Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Claims;
using Entities.Models;

namespace PillSpot.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PharmacyProductNotificationPreferenceController : ControllerBase
    {
        private readonly IPharmacyProductNotificationPreferenceService _preferenceService;
        private readonly ILogger<PharmacyProductNotificationPreferenceController> _logger;

        public PharmacyProductNotificationPreferenceController(
            IPharmacyProductNotificationPreferenceService preferenceService,
            ILogger<PharmacyProductNotificationPreferenceController> logger)
        {
            _preferenceService = preferenceService;
            _logger = logger;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductPreference(Guid productId, [FromQuery] Guid? pharmacyId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var preference = await _preferenceService.GetUserProductPreferenceAsync(userId, productId, pharmacyId);
            return Ok(preference);
        }

        [HttpGet("product/{productId}/all")]
        public async Task<IActionResult> GetProductPreferences(Guid productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var preferences = await _preferenceService.GetUserProductPreferencesAsync(userId, productId);
            return Ok(preferences);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserPreferences()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var preferences = await _preferenceService.GetUserPreferencesAsync(userId);
            return Ok(preferences);
        }

        [HttpPost("product/{productId}")]
        public async Task<IActionResult> CreatePreference(Guid productId, [FromBody] PharmacyProductNotificationPreferenceForCreationDto preferenceDto, [FromQuery] Guid? pharmacyId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var preference = await _preferenceService.CreatePreferenceAsync(userId, productId, pharmacyId, preferenceDto);
            return CreatedAtAction(nameof(GetProductPreference), new { productId, pharmacyId }, preference);
        }

        [HttpPut("product/{productId}")]
        public async Task<IActionResult> UpdatePreference(Guid productId, [FromBody] PharmacyProductNotificationPreferenceForUpdateDto preferenceDto, [FromQuery] Guid? pharmacyId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _preferenceService.UpdatePreferenceAsync(userId, productId, pharmacyId, preferenceDto);
            return NoContent();
        }

        [HttpDelete("product/{productId}")]
        public async Task<IActionResult> DeletePreference(Guid productId, [FromQuery] Guid? pharmacyId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _preferenceService.DeletePreferenceAsync(userId, productId, pharmacyId);
            return NoContent();
        }

        [HttpGet("product/{productId}/type/{notificationType}")]
        public async Task<IActionResult> GetPreferencesForProductAndType(Guid productId, NotificationType notificationType)
        {
            var preferences = await _preferenceService.GetPreferencesForProductAndTypeAsync(productId, notificationType);
            return Ok(preferences);
        }
    }
} 