using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/cosmetics")]
    [ApiController]
    public class CosmeticController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CosmeticController(IServiceManager service) => _service = service;

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetCosmetic(long id)
        {
            var cosmetic = await _service.CosmeticService.GetCosmeticAsync((ulong)id, trackChanges: false);
            return Ok(cosmetic);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCosmetic([FromBody] CosmeticForCreationDto cosmeticDto)
        {
            var createdCosmetic = await _service.CosmeticService.CreateCosmeticAsync(cosmeticDto);
            return CreatedAtAction(nameof(GetCosmetic), new { id = createdCosmetic.ProductId }, createdCosmetic);
        }

        [HttpDelete("{id:long}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCosmetic(long id)
        {
            await _service.CosmeticService.DeleteCosmetic((ulong)id, trackChanges: true);
            return NoContent();
        }
    }
}