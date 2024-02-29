using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcMovie.Data.Security
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.RouteValues.ContainsKey("Controller") && context.ActionDescriptor.RouteValues["Controller"].ToString() == "Login")
                return;

            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }
    }
}
