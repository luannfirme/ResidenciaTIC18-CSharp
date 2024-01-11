using Microsoft.EntityFrameworkCore;
using techmed;
using Techmed.Entities;

namespace Techmed.Model;

public class TechmedContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var stringConexao = "server=localhost;user=dotnet;password=tic2023;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(stringConexao);
        optionsBuilder.UseMySql(stringConexao, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Medico>().ToTable("Medicos").HasKey(m => m.Id);
        modelBuilder.Entity<Paciente>().ToTable("Pacientes").HasKey(p => p.Id);
    }
}
