using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;
using System.Linq;

namespace PillSpot.Presentation.ActionFilters
{
    public class ValidateCsrfTokenAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            if (method == HttpMethods.Post || method == HttpMethods.Put || method == HttpMethods.Patch || method == HttpMethods.Delete)
            {
                // Get CSRF token from header (case-insensitive)
                var csrfTokenFromHeader = context.HttpContext.Request.Headers
                    .FirstOrDefault(h => h.Key.Equals("X-Csrf-Token", StringComparison.OrdinalIgnoreCase))
                    .Value.ToString();
                
                var csrfTokenFromCookie = context.HttpContext.Request.Cookies["CsrfToken"];

                if (string.IsNullOrEmpty(csrfTokenFromHeader) || string.IsNullOrEmpty(csrfTokenFromCookie))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var securityService = context.HttpContext.RequestServices.GetRequiredService<IServiceManager>().SecurityService;
                var isValid = await securityService.ValidateCsrfTokenAsync(csrfTokenFromHeader, csrfTokenFromCookie);

                if (!isValid)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }

            await next();
        }
    }
}
