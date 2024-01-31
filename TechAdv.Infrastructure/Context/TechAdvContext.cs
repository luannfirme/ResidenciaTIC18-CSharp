using Microsoft.EntityFrameworkCore;
using TechAdv.Domain.Entities;

namespace TechAdv.Persistence.Context
{
    public class TechAdvContext : DbContext
    {
        public TechAdvContext(DbContextOptions<TechAdvContext> options) : base(options)
        {
        }

        public DbSet<Advogado> Advogads { get; set; }
        public DbSet<CasoJuridico> CasoJuridicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Documento> Documentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechAdvContext).Assembly);
        }
    }
}
