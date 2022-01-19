using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class MunicipiosConfiguration : IEntityTypeConfiguration<Municipios>
    {
        public void Configure(EntityTypeBuilder<Municipios> builder)
        {
            builder.HasKey(e => e.IdMunicipio);

            builder.ToTable("Municipios", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdProvinciaNavigation)
                .WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Municipios_Provincias");
        }
    }
}
