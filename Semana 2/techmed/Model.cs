using Microsoft.EntityFrameworkCore;
using Techmed.Entities;

namespace Techmed.Model;

public class TechmedContext : DbContext
{
    public TechmedContext(){

    }
    
    DbSet<Paciente> Pacientes;
    DbSet<Medico> Medicos;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var stringConexao= "server=localhost;user=dotnet;password=tic2023;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(stringConexao);
        optionsBuilder.UseMySql(stringConexao, serverVersion);
    }
}
