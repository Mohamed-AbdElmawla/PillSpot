using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Contracts;

namespace PillSpot.Presentation.ActionFilters
{
    public class PermissionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _requiredPermission;
        private readonly bool _isAdminCheck;

        public PermissionFilterAttribute(string requiredPermission, bool isAdminCheck = false)
        {
            _requiredPermission = requiredPermission;
            _isAdminCheck = isAdminCheck;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = context.HttpContext.User.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var serviceProvider = context.HttpContext.RequestServices;

            if (_isAdminCheck)
            {
                var adminPermissionService = (IAdminPermissionService)serviceProvider.GetService(typeof(IAdminPermissionService));
                if (adminPermissionService == null)
                {
                    context.Result = new StatusCodeResult(500);
                    return;
                }

                var hasPermission = await adminPermissionService.HasPermissionAsync(userId, _requiredPermission);
                if (!hasPermission)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
            else
            {
                var employeePermissionService = (IEmployeePermissionService)serviceProvider.GetService(typeof(IEmployeePermissionService));
                if (employeePermissionService == null)
                {
                    context.Result = new StatusCodeResult(500);
                    return;
                }

                var hasPermission = await employeePermissionService.HasPermissionAsync(userId, _requiredPermission);
                if (!hasPermission)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
            await next();
        }
    }
}