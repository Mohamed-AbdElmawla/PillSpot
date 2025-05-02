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
    [Route("api/carts/{cartId:guid}/items")]
    [ApiController]
    [Authorize]
    public class CartItemController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CartItemController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems(Guid cartId, [FromQuery] CartItemRequestParameters parameters)
        {
            var (items, metaData) = await _service.CartItemService.GetCartItemsByCartIdAsync(cartId, parameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
            return Ok(items);
        }

        [HttpGet("pharmacy/{pharmacyId:guid}")]
        public async Task<IActionResult> GetItemsByPharmacy(Guid cartId, Guid pharmacyId)
        {
            var items = await _service.CartItemService.GetItemsByPharmacyAsync(cartId, pharmacyId);
            return Ok(items);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetCartItemsWithDetails(Guid cartId)
        {
            var items = await _service.CartItemService.GetCartItemsWithDetailsAsync(cartId);
            return Ok(items);
        }

        [HttpGet("product/{productId:guid}/pharmacy/{pharmacyId:guid}")]
        public async Task<IActionResult> GetCartItem(Guid cartId, Guid productId, Guid pharmacyId)
        {
            var item = await _service.CartItemService.GetCartItemByIdsAsync(cartId, productId, pharmacyId);
            return Ok(item);
        }

        [HttpGet("pending-approval")]
        [Authorize(Roles = "SuperAdmin,Admin,Pharmacy")]
        public async Task<IActionResult> GetPendingApprovalItems(Guid cartId)
        {
            var items = await _service.CartItemService.GetPendingApprovalItemsAsync(cartId);
            return Ok(items);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCartItem(Guid cartId, [FromForm] CartItemForCreationDto itemDto)
        {
            if (itemDto.CartId != cartId)
                return BadRequest("CartId in DTO does not match the route parameter.");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cart = await _service.CartService.GetCartAsync(cartId);
            if (cart.UserId != userId && !User.IsInRole("SuperAdmin") && !User.IsInRole("Admin"))
                return Forbid("You are not authorized to modify this cart.");

            var createdItem = await _service.CartItemService.CreateCartItemAsync(itemDto);
            return CreatedAtAction(nameof(GetCartItem), new { cartId, productId = createdItem.ProductId, pharmacyId = createdItem.PharmacyId }, createdItem);
        }

        [HttpPut("product/{productId:guid}/pharmacy/{pharmacyId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCartItem(Guid cartId, Guid productId, Guid pharmacyId, [FromForm] CartItemForUpdateDto itemDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cart = await _service.CartService.GetCartAsync(cartId);
            if (cart.UserId != userId && !User.IsInRole("SuperAdmin") && !User.IsInRole("Admin"))
                return Forbid("You are not authorized to modify this cart.");

            await _service.CartItemService.UpdateCartItemAsync(cartId, productId, pharmacyId, itemDto);
            return NoContent();
        }

        [HttpDelete("product/{productId:guid}/pharmacy/{pharmacyId:guid}")]
        public async Task<IActionResult> DeleteCartItem(Guid cartId, Guid productId, Guid pharmacyId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cart = await _service.CartService.GetCartAsync(cartId);
            if (cart.UserId != userId && !User.IsInRole("SuperAdmin") && !User.IsInRole("Admin"))
                return Forbid("You are not authorized to modify this cart.");

            await _service.CartItemService.DeleteCartItemAsync(cartId, productId, pharmacyId);
            return NoContent();
        }

        [HttpPut("approvals")]
        [Authorize(Roles = "SuperAdmin,Admin,Pharmacy")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateItemApprovals(Guid cartId, [FromBody] IEnumerable<CartItemApprovalDto> approvals)
        {
            await _service.CartItemService.UpdateItemApprovalsAsync(cartId, approvals);
            return NoContent();
        }
    }
}