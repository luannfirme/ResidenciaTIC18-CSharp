namespace MinimalAPI.MiddlewareExtensions
{
    public class MotorMiddleware
    {
        private readonly RequestDelegate _next;
        private List<string> _response;

        public MotorMiddleware(RequestDelegate next, List<string> response)
        {
            _next = next;
            _response = response;
        }

        public async Task Invoke(HttpContext context)
        {
            _response.Add("Motor Add");
            await _next.Invoke(context);
            _response.Add("Motor Ok");
        }
    }

    public static class MotorMiddlewareExtensions
    {
        public static IApplicationBuilder UseMotorMiddleware(this IApplicationBuilder builder, List<string> response)
        {
            return builder.UseMiddleware<MotorMiddleware>(response);
        }
    }
}
