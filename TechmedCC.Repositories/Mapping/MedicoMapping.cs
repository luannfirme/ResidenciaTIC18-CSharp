using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechmedCC.Entities.Entities;

namespace TechmedCC.Infra.Mapping
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");

            builder.HasKey(m => m.Id);
        }
    }
}
