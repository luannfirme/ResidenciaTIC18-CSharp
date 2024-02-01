namespace MinimalAPI.MiddlewareExtensions
{
    public class PinturaMiddleware
    {
        private readonly RequestDelegate _next;
        private List<string> _response;

        public PinturaMiddleware(RequestDelegate next, List<string> response)
        {
            _next = next;
            _response = response;
        }

        public async Task Invoke(HttpContext context)
        {
            _response.Add("Pintura Add");
            await _next.Invoke(context);
            _response.Add("Pintura Ok");
        }
    }

    public static class PinturaMiddlewareExtensions
    {
        public static IApplicationBuilder UsePinturaMiddleware(this IApplicationBuilder builder, List<string> response)
        {
            return builder.UseMiddleware<PinturaMiddleware>(response);
        }
    }
}
