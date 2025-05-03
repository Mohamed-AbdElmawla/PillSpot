using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;
using System.Security.Claims;

namespace PillSpot.Presentation.ActionFilters
{
    public class PermissionAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string[] _requiredPermissions;

        public PermissionAuthorizeAttribute(params string[] requiredPermissions) => _requiredPermissions = requiredPermissions;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpContext = context.HttpContext;
            var user = httpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new ForbidResult();
                return;
            }

            var userRoles = user.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            var service = httpContext.RequestServices.GetRequiredService<IServiceManager>();

            if (userRoles.Contains("SuperAdmin"))
            {
                await next();
                return;
            }

            if (userRoles.Contains("Admin"))
            {
                foreach (var permission in _requiredPermissions)
                {
                    var hasAdminPermission = await service.AdminPermissionService.AdminHasPermissionAsync(userId, permission,false);
                    if (hasAdminPermission)
                    {
                        await next();
                        return;
                    }
                }

                context.Result = new ForbidResult();
                return;
            }

            if (!context.ActionArguments.TryGetValue("pharmacyId", out var pharmacyIdObj) || pharmacyIdObj is not Guid pharmacyId)
            {
                context.Result = new BadRequestObjectResult("PharmacyId is required.");
                return;
            }

            var employee = await service.PharmacyEmployeeService.GetPharmacyEmployeeAsync(userId, pharmacyId, false);
            if (employee is null)
            {
                context.Result = new ForbidResult();
                return;
            }

            var roleName = await service.PharmacyEmployeeService.GetEmployeeRoleNameAsync(employee.EmployeeId,trackChanges:false);
            if (roleName == "PharmacyOwner" || roleName == "PharmacyManager")
            {
                await next();
                return;
            }

            foreach (var permission in _requiredPermissions)
            {
                var hasPermission = await service.EmployeePermissionService.EmployeeHasPermissionAsync(employee.EmployeeId, permission,false);
                if (hasPermission)
                {
                    await next();
                    return;
                }
            }
            context.Result = new ForbidResult(); 
        }
    }

}