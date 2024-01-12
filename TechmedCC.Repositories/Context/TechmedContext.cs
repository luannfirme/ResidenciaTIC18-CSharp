using Microsoft.EntityFrameworkCore;
using TechmedCC.Domain.Entities;

namespace TechmedCC.Infra.Context
{
    public class TechmedContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var stringConexao = "";
            var serverVersion = ServerVersion.AutoDetect(stringConexao);
            optionsBuilder.UseMySql(stringConexao, serverVersion);
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Exame> Exames { get; set; }

    }
}
