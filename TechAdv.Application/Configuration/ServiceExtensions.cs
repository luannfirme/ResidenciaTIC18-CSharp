using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TechAdv.Application.Configuration
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

        }
    }
}