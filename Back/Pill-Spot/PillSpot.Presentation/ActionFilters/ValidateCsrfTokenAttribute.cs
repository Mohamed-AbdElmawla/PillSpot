using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Antiforgery;

namespace PillSpot.Presentation.ActionFilters
{
    public class ValidateCsrfTokenAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            if (method == HttpMethods.Post || method == HttpMethods.Put || method == HttpMethods.Patch || method == HttpMethods.Delete)
            {
                try
                {
                    var antiforgery = context.HttpContext.RequestServices.GetRequiredService<IAntiforgery>();
                    await antiforgery.ValidateRequestAsync(context.HttpContext);
                }
                catch (Exception)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }

            await next();
        }
    }
}
