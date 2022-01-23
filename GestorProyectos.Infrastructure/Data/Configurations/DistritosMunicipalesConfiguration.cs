using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DistritosMunicipalesConfiguration : IEntityTypeConfiguration<DistritosMunicipales>
    {
        public void Configure(EntityTypeBuilder<DistritosMunicipales> builder)
        {
            builder.HasKey(e => e.IdDistrito);

            builder.ToTable("DistritosMunicipales", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.HasOne(d => d.Municipio)
                .WithMany(p => p.DistritosMunicipales)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DistritosMunicipales_Municipios");
        }
    }
}