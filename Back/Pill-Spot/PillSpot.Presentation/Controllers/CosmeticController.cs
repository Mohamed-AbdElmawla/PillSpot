using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/cosmetics")]
    [ApiController]
    public class CosmeticController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CosmeticController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllCosmetics([FromQuery] CosmeticRequestParameters cosmeticRequestParameters)
        {
            var pagedResult = await _service.CosmeticService.GetAllCosmeticsAsync(cosmeticRequestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.cosmetics);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCosmetic(Guid id)
        {
            var cosmetic = await _service.CosmeticService.GetCosmeticAsync(id, trackChanges: false);
            return Ok(cosmetic);
        }

        [HttpPost]
        [ValidateCsrfToken]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [UserAuthorization("CosmeticsManagement")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCosmetic([FromForm] CosmeticForCreationDto cosmeticForCreationDto)
        {
            var createdCosmetic = await _service.CosmeticService.CreateCosmeticAsync(cosmeticForCreationDto, trackChanges: true);
            return CreatedAtAction(nameof(GetCosmetic), new { id = createdCosmetic.ProductId }, createdCosmetic);
        }

        [HttpPatch("{id:Guid}")]
        [ValidateCsrfToken]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [UserAuthorization("CosmeticsManagement")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCosmetic(Guid id,[FromForm] CosmeticForUpdateDto cosmeticForUpdateDto)
        {
            await _service.CosmeticService.UpdateCosmeticAsync(id, cosmeticForUpdateDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ValidateCsrfToken]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [UserAuthorization("CosmeticsManagement")]
        public async Task<IActionResult> DeleteCosmetic(Guid id)
        {
            await _service.CosmeticService.DeleteCosmeticAsync(id, trackChanges: true);
            return NoContent();
        }
    }
}