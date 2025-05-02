using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Security.Claims;
using System.Text.Json;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/carts")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CartController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetAllCarts([FromQuery] CartRequestParameters cartParameters)
        {
            var (carts, metaData) = await _service.CartService.GetAllCartsAsync(cartParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(carts);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCart(Guid id)
        {
            var cart = await _service.CartService.GetCartAsync(id);
            return Ok(cart);
        }

        [HttpGet("{id:guid}/items")]
        public async Task<IActionResult> GetCartWithItems(Guid id)
        {
            var cart = await _service.CartService.GetCartWithItemsAsync(id);
            return Ok(cart);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserCart()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            var cart = await _service.CartService.GetUserCartAsync(userId);
            return Ok(cart);
        }

        [HttpGet("guest/{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGuestCart(Guid id)
        {
            var cart = await _service.CartService.GetGuestCartAsync(id);
            return Ok(cart);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCart([FromBody] CartForCreationDto cartDto)
        {
            var createdCart = await _service.CartService.CreateCartAsync(cartDto);
            return CreatedAtAction(nameof(GetCart), new { id = createdCart.CartId }, createdCart);
        }

        [HttpPost("collection")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCartCollection([FromBody] IEnumerable<CartForCreationDto> cartCollection)
        {
            var (createdCarts, ids) = await _service.CartService.CreateCartCollectionAsync(cartCollection);
            return CreatedAtAction(nameof(GetCartCollection), new { ids }, createdCarts);
        }

        [HttpGet("collection/{ids}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetCartCollection([FromRoute] string ids, [FromQuery] CartRequestParameters parameters)
        {
            var idArray = ids.Split(',').Select(Guid.Parse);
            var (carts, metaData) = await _service.CartService.GetAllCartsAsync(parameters);
            var filteredCarts = carts.Where(c => idArray.Contains(c.CartId));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(filteredCarts);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCart(Guid id, [FromBody] CartForUpdateDto cartDto)
        {
            await _service.CartService.UpdateCartAsync(id, cartDto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            await _service.CartService.DeleteCartAsync(id);
            return NoContent();
        }

        [HttpPut("{id:guid}/lock")]
        public async Task<IActionResult> LockCart(Guid id)
        {
            await _service.CartService.LockCartAsync(id);
            return NoContent();
        }

        [HttpPut("{id:guid}/unlock")]
        public async Task<IActionResult> UnlockCart(Guid id)
        {
            await _service.CartService.UnlockCartAsync(id);
            return NoContent();
        }

        [HttpDelete("guest/cleanup")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> CleanupExpiredGuestCarts()
        {
            await _service.CartService.CleanupExpiredGuestCartsAsync(DateTime.UtcNow);
            return NoContent();
        }

        [HttpGet("{id:guid}/item-count")]
        public async Task<IActionResult> GetCartItemCount(Guid id)
        {
            var count = await _service.CartService.GetCartItemCountAsync(id);
            return Ok(new { ItemCount = count });
        }

        [HttpGet("{id:guid}/pharmacy-totals")]
        public async Task<IActionResult> GetCartPharmacyTotals(Guid id)
        {
            var totals = await _service.CartService.GetCartPharmacyTotalsAsync(id);
            return Ok(totals);
        }
    }
}