﻿using Microsoft.AspNetCore.Mvc;
using PillSpot.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyEmployeePermissionController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PharmacyEmployeePermissionController(IServiceManager service ) => _service = service;


        [HttpGet("{employeeId}", Name = "GetEmployeePermissions")]
        [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager")]
        [PermissionAuthorize("PharmacyEmployeePermissionManagement")]
        public async Task<IActionResult> GetPermissionsFromEmployee(Guid employeeId)
        {
            var result = await _service.EmployeePermissionService.GetPermissionsToEmployeeAsync(employeeId, trackChanges: false);
            return Ok(result);
        }


        [HttpPost("assign")]
        [ValidateCsrfToken]
   //     [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager")]
    //    [PermissionAuthorize("PharmacyEmployeePermissionManagement")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AssignPermissionToEmployee([FromBody] AssignEmployeePermissionDto assignEmployeePermissionDto)
        {
            var result = await _service.EmployeePermissionService.AssignPermissionToEmployeeAsync(assignEmployeePermissionDto);
            return CreatedAtRoute("GetEmployeePermissions", new { EmployeeID = result.EmployeeId }, result);
        }


        [HttpPost("assign-multiple/{employeeId}")]
       // [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager")]
       // [PermissionAuthorize("PharmacyEmployeePermissionManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> AssignPermissionsToEmployee(Guid employeeId, [FromBody] IEnumerable<Guid> permissionIds)
        {
            var result = await _service.EmployeePermissionService.AssignPermissionsToEmployeeAsync(employeeId, permissionIds);
            return CreatedAtRoute("GetEmployeePermissions", new { EmployeeId = employeeId }, result);
        }


        [HttpDelete("remove/{employeeId}/{permissionId}")]
    //    [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager")]
      //  [PermissionAuthorize("PharmacyEmployeePermissionManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> RemovePermissionFromEmployee(Guid employeeId, Guid permissionId)
        {
            await _service.EmployeePermissionService.RemovePermissionFromEmployeeAsync(employeeId, permissionId);
            return NoContent();
        }


        [HttpDelete("remove-multiple/{employeeId}")]
  //      [PharmacyRoleAuthorize("PharmacyOwner", "PharmacyManager")]
   //     [PermissionAuthorize("PharmacyEmployeePermissionManagement")]
        [ValidateCsrfToken]
        public async Task<IActionResult> RemovePermissionsFromEmployee(Guid employeeId, [FromBody] IEnumerable<Guid> permissionIds)
        {
            await _service.EmployeePermissionService.RemovePermissionsFromEmployeeAsync(employeeId, permissionIds);
            return NoContent();
        }
    }
}
