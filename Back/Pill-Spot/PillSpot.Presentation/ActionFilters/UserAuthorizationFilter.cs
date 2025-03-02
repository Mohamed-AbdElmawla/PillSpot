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
    public class UserAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string[] _allowedRoles;

        public UserAuthorizationFilter(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles ?? Array.Empty<string>();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user?.Identity is not { IsAuthenticated: true })
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (_allowedRoles.Length > 0 && _allowedRoles.Any(user.IsInRole))
                return;

            context.Result = new ForbidResult();
        }
    }
}