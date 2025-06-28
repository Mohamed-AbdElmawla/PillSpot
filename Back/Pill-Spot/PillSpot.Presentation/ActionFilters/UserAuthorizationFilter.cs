using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

public class UserAuthorizationFilter : IAuthorizationFilter
{
    private readonly string _parameterName;
    public UserAuthorizationFilter(string parameterName = "userName") =>
        _parameterName = parameterName;

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

        var isSuperAdmin = user.IsInRole("SuperAdmin");
        var isAdmin = user.IsInRole("Admin");
        var hasUserManagementPermission = user.HasClaim("Permission", "UserManagement");

        var isOwner = currentUserName == userName;

        if (isOwner)
            return;

        if (isSuperAdmin)
            return;

        if (isAdmin && hasUserManagementPermission)
            return;

        context.Result = new ForbidResult();
    }
}
