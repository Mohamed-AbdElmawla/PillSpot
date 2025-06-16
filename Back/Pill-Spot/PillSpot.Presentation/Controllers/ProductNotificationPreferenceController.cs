using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PillSpot.Service.Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Security.Claims;

namespace PillSpot.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductNotificationPreferenceController : ControllerBase
    {
        private readonly IProductNotificationPreferenceService _preferenceService;
        private readonly ILogger<ProductNotificationPreferenceController> _logger;

        public ProductNotificationPreferenceController(
            IProductNotificationPreferenceService preferenceService,
            ILogger<ProductNotificationPreferenceController> logger)
        {
            _preferenceService = preferenceService;
            _logger = logger;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetProductPreference(Guid productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                var preference = await _preferenceService.GetUserProductPreferenceAsync(userId, productId);
                return Ok(preference);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product notification preference");
                return NotFound();
            }
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
        public async Task<IActionResult> CreatePreference(Guid productId, [FromBody] ProductNotificationPreferenceForCreationDto preferenceDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                var preference = await _preferenceService.CreatePreferenceAsync(userId, productId, preferenceDto);
                return CreatedAtAction(nameof(GetProductPreference), new { productId }, preference);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product notification preference");
                return BadRequest();
            }
        }

        [HttpPut("product/{productId}")]
        public async Task<IActionResult> UpdatePreference(Guid productId, [FromBody] ProductNotificationPreferenceForUpdateDto preferenceDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                await _preferenceService.UpdatePreferenceAsync(userId, productId, preferenceDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product notification preference");
                return BadRequest();
            }
        }

        [HttpDelete("product/{productId}")]
        public async Task<IActionResult> DeletePreference(Guid productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                await _preferenceService.DeletePreferenceAsync(userId, productId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product notification preference");
                return BadRequest();
            }
        }
    }
} 