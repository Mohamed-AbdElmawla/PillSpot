using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/users/{userId}/addresses")]
    [ApiController]
    [Authorize]
    public class UserAddressController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserAddressController(IServiceManager service) =>_service = service;

        [HttpGet]
        public async Task<IActionResult> GetAddressesForUser(string userId, [FromQuery] UserAddressRequestParameters parameters)
        {
            var (addresses, metaData) = await _service.UserAddressService
                .GetAddressesForUserAsync(userId, parameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(addresses);
        }

        [HttpGet("{addressId:guid}", Name = "UserAddressById")]
        public async Task<IActionResult> GetUserAddress(string userId, Guid addressId)
        {
            var address = await _service.UserAddressService
                .GetAddressAsync(userId, addressId, trackChanges: false);

            return Ok(address);
        }

        [HttpGet("default", Name = "UserDefaultAddress")]
        public async Task<IActionResult> GetDefaultAddress(string userId)
        {
            var address = await _service.UserAddressService
                .GetDefaultAddressAsync(userId, trackChanges: false);

            return Ok(address);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateUserAddress(string userId, [FromBody] UserAddressForCreationDto addressDto)
        {
            var address = await _service.UserAddressService
                .CreateAddressAsync(userId, addressDto);

            return CreatedAtRoute("UserAddressById",
                new { userId, addressId = address.AddressId },
                address);
        }

        [HttpPut("{addressId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUserAddress(string userId, Guid addressId,
            [FromBody] UserAddressForUpdateDto addressDto)
        {
            await _service.UserAddressService
                .UpdateAddressAsync(userId, addressId, addressDto, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{addressId:guid}")]
        public async Task<IActionResult> DeleteUserAddress(string userId, Guid addressId)
        {
            await _service.UserAddressService
                .DeleteAddressAsync(userId, addressId, trackChanges: true);

            return NoContent();
        }

        [HttpPatch("{addressId:guid}/set-default")]
        public async Task<IActionResult> SetDefaultAddress(string userId, Guid addressId)
        {
            await _service.UserAddressService
                .SetDefaultAddressAsync(userId, addressId, trackChanges: true);

            return NoContent();
        }
    }
}