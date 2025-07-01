using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace PillSpot.Presentation.ActionFilters
{
    public class UserAuthorizationAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _parameterName;
        private readonly string _requiredPermission;

        public UserAuthorizationAttribute(string requiredPermission, string parameterName = null)
        {
            _parameterName = parameterName;
            _requiredPermission = requiredPermission;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;
            var httpContext = context.HttpContext;

            // Check if user is authenticated
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Try get the route parameter
            string userName = null;
            if (_parameterName is not null)
            {
                if (context.ActionArguments.ContainsKey(_parameterName))
                    userName = context.ActionArguments[_parameterName]?.ToString();
                else if (context.RouteData.Values.TryGetValue(_parameterName, out var routeValue))
                    userName = routeValue?.ToString();
            }
            var currentUserName = user.FindFirst(ClaimTypes.Name)?.Value;
            var service = httpContext.RequestServices.GetRequiredService<IServiceManager>();
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isSuperAdmin = user.IsInRole("SuperAdmin");
            var isAdmin = user.IsInRole("Admin");
            var hasRequiredPermission = await service.AdminPermissionService.AdminHasPermissionAsync(userId, _requiredPermission, false);
            var isOwner = string.Equals(currentUserName, userName, StringComparison.OrdinalIgnoreCase) || _parameterName is null;

            if (isOwner || isSuperAdmin || (isAdmin && hasRequiredPermission))
                await next(); // Authorized
            else
                context.Result = new ForbidResult(); // Forbidden
        }
    }
}