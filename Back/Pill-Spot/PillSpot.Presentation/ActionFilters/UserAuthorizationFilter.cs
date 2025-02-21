using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        var authenticatedUserName = user.Identity.Name ?? string.Empty;
        var routeUserName = context.RouteData.Values["userName"]?.ToString() ?? string.Empty;
        if (_allowedRoles.Length > 0 && _allowedRoles.Any(user.IsInRole))
            return;

        if (!string.IsNullOrEmpty(routeUserName) &&
            string.Equals(authenticatedUserName, routeUserName, StringComparison.OrdinalIgnoreCase))
            return;

        context.Result = new ForbidResult();
    }
}
