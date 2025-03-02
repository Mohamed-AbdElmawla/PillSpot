using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillSpot.Presentation.ActionFilters
{
    public class ValidateCsrfTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Method == HttpMethods.Post)
            {
                var csrfTokenFromHeader = context.HttpContext.Request.Headers["X-Csrf-Token"];
                var csrfTokenFromCookie = context.HttpContext.Request.Cookies["CsrfToken"];

                if (csrfTokenFromHeader != csrfTokenFromCookie)
                {
                    context.Result = new UnauthorizedResult();
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
