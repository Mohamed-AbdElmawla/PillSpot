using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Contracts;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace PillSpot.Presentation.ActionFilters
{
    public class PharmacyRoleAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string[] _requiredPharmacyRoles;
        private readonly string[] _globalRoles = new[] { "Admin", "SuperAdmin" };

        public PharmacyRoleAuthorizeAttribute(params string[] requiredPharmacyRoles)
        {
            _requiredPharmacyRoles = requiredPharmacyRoles;
        }

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

            if (userRoles.Any(role => _globalRoles.Contains(role)))
            {
                await next();
                return;
            }

            Guid pharmacyId = Guid.Empty;

            if (context.ActionArguments.TryGetValue("pharmacyId", out var pharmacyIdObj) && pharmacyIdObj is Guid idFromParam)
            {
                pharmacyId = idFromParam;
            }
            else
            {
                foreach (var arg in context.ActionArguments.Values)
                {
                    if (arg == null) continue;

                    var prop = arg.GetType().GetProperty("PharmacyId");
                    if (prop != null)
                    {
                        var value = prop.GetValue(arg);
                        if (value is Guid idFromDto)
                        {
                            pharmacyId = idFromDto;
                            break;
                        }
                    }
                }
            }

            if (pharmacyId == Guid.Empty)
            {
                context.Result = new BadRequestObjectResult("PharmacyId is required.");
                return;
            }

            var service = httpContext.RequestServices.GetService<IServiceManager>();
            foreach (var role in _requiredPharmacyRoles)
            {
                var hasRole = await service.PharmacyEmployeeRoleService.UserHasRoleInPharmacyAsync(userId, role, pharmacyId, false);

                if (hasRole)
                {
                    await next();
                    return;
                }
            }

            context.Result = new ForbidResult();
        }
    }

}

