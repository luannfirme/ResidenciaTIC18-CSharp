namespace MinimalAPI
{
    public class ExampleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Sem curto Circuito \n");
            await _next.Invoke(context);
            await context.Response.WriteAsync("Segunda pasasgem");
        }
    }
    public static class ExampleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExampleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExampleMiddleware>();
        }
    }

}
