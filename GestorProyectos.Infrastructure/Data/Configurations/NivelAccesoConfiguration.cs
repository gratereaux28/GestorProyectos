using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class NivelAccesoConfiguration : IEntityTypeConfiguration<NivelAcceso>
    {
        public void Configure(EntityTypeBuilder<NivelAcceso> builder)
        {
            builder.HasKey(e => e.IdNivelAcceso)
                .HasName("PK__NivelAcc__0C3A5FBCDBA10DC5");

            builder.ToTable("NivelAcceso", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}