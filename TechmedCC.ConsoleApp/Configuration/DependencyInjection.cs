using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechmedCC.Domain.Entities;
using TechmedCC.Domain.Interfaces;
using TechmedCC.Infra.Context;
using TechmedCC.Infra.UoW;

namespace TechmedCC.ConsoleApp.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection InsertInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TechmedContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"), null));

            services.AddScoped<IAtendimento, Atendimento>();
            services.AddScoped<IExame, Exame>();
            services.AddScoped<IMedico, Medico>();
            services.AddScoped<IPaciente, Paciente>();
            services.AddScoped<IPessoa, Pessoa>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
