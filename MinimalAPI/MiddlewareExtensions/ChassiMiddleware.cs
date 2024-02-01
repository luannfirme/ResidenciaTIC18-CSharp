namespace MinimalAPI.MiddlewareExtensions
{
    public class ChassiMiddleware
    {
        private readonly RequestDelegate _next;
        private List<string> _response;

        public ChassiMiddleware(RequestDelegate next, List<string> response)
        {
            _next = next;
            _response = response;
        }

        public async Task Invoke(HttpContext context)
        {
             _response.Add("Chassi Add");
            await _next.Invoke(context);
            await context.Response.WriteAsync(String.Join("\n", _response));
        }
    }

    public static class ChassiMiddlewareExtensions
    {
        public static IApplicationBuilder UseChassiMiddleware(this IApplicationBuilder builder, List<string> response)
        {
            return builder.UseMiddleware<ChassiMiddleware>(response);
        }
    }
}
