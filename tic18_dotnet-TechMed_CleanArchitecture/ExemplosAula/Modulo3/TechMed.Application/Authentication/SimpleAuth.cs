using System.Text;

namespace TechMed.Application.Authentication
{
    public sealed class SimpleAuth
    {
        //    private readonly RequestDelegate _next;

        //    public SimpleAuth(RequestDelegate next)
        //    {
        //        _next = next;
        //    }

        //    public async Task InvokeAsync(HttpContext context)
        //    {
        //        if (!context.Request.Headers.ContainsKey("Authorization"))
        //        {
        //            context.Response.StatusCode = 401;
        //            await context.Response.WriteAsync("Authorization header is missing");
        //            return;
        //        }

        //        var header = context.Request.Headers["Authorization"].ToString();
        //        var encondedUsernamePassword = header.Substring(6);
        //        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encondedUsernamePassword));

        //        string[] usernamePassword = decodedUsernamePassword.Split(":");

        //        var username = usernamePassword[0];
        //        var password = usernamePassword[1];

        //        if (username != "admin" || password != "admin")
        //        {
        //            context.Response.StatusCode = 401;
        //            await context.Response.WriteAsync("Invalid username or password");
        //            return;
        //        }

        //        await _next(context);
        //    }
        //}

        //public static class AuthExtensions
        //{
        //    public static UseAuthentication(IApplicationBuilder builder)
        //    {
        //        return builder.UseMiddleware<SimpleAuth>();
        //    }
    }
}
