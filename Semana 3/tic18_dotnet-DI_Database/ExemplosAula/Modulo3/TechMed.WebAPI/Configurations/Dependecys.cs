using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Infra.Data;

namespace TechMed.WebAPI.Configurations
{
    public static class Dependecys
    {

        public static IServiceCollection DependecyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMedicoCollection, MedicosDB>();
            services.AddSingleton<IPacienteCollection, PacienteDB>();

            return services;
        }
    }
}
