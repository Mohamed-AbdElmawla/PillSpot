using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

public class UserAuthorizationFilter : IAuthorizationFilter
{
    private readonly string _parameterName;

    public UserAuthorizationFilter(string parameterName = "userName")
    {
        _parameterName = parameterName;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (!user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userName = context.RouteData.Values[_parameterName]?.ToString();
        var currentUserName = user.FindFirst(ClaimTypes.Name)?.Value;

        if (currentUserName != userName && !user.IsInRole("Admin"))
        {
            context.Result = new ForbidResult();
        }
    }
}