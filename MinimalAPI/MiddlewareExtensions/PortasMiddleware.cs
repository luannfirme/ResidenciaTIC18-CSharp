namespace MinimalAPI.MiddlewareExtensions
{
    public class PortasMiddleware
    {
        private readonly RequestDelegate _next;
        private List<string> _response;

        public PortasMiddleware(RequestDelegate next, List<string> response)
        {
            _next = next;
            _response = response;
        }

        public async Task Invoke(HttpContext context)
        {
            _response.Add("Portas Add");
            await _next.Invoke(context);
            _response.Add("Portas Ok");
        }
    }

    public static class PortasMiddlewareExtensions
    {
        public static IApplicationBuilder UsePortasMiddleware(this IApplicationBuilder builder, List<string> response)
        {
            return builder.UseMiddleware<PortasMiddleware>(response);
        }
    }
}
