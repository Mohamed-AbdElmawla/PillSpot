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
                catch (AntiforgeryValidationException ex)
                {
                    var headerToken = context.HttpContext.Request.Headers["X-CSRF-Token"].FirstOrDefault();
                    var cookieToken = context.HttpContext.Request.Cookies["CsrfToken"];

                    context.Result = new JsonResult(new
                    {
                        success = false,
                        error = "CSRF token validation failed",
                        message = ex.Message,
                        tokenFromHeader = headerToken ?? "Not provided",
                        tokenFromCookie = cookieToken ?? "Not present"
                    })
                    {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                    return;
                }
                catch (Exception ex)
                {
                    context.Result = new JsonResult(new
                    {
                        success = false,
                        error = "Unexpected error during CSRF validation",
                        message = ex.Message
                    })
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                    return;
                }
            }

            await next();
        }
    }
}