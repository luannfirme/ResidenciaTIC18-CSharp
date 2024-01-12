using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechmedCC.Entities.Entities;

namespace TechmedCC.Infra.Mapping
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");

            builder.HasKey(m => m.Id);
        }
    }
}
