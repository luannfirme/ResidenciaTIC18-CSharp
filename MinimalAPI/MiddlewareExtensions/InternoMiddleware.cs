namespace MinimalAPI.MiddlewareExtensions
{
    public class InternoMiddleware
    {
        private readonly RequestDelegate _next;
        private List<string> _response;

        public InternoMiddleware(RequestDelegate next, List<string> response)
        {
            _next = next;
            _response = response;
        }

        public async Task Invoke(HttpContext context)
        {
            _response.Add("Interno Add");
            await _next.Invoke(context);
            _response.Add("Interno Ok");
        }
    }

    public static class InternoMiddlewareExtensions
    {
        public static IApplicationBuilder UseInternoMiddleware(this IApplicationBuilder builder, List<string> response)
        {
            return builder.UseMiddleware<InternoMiddleware>(response);
        }
    }
}
