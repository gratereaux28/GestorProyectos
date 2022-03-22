using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class SeccionesConfiguration : IEntityTypeConfiguration<Secciones>
    {
        public void Configure(EntityTypeBuilder<Secciones> builder)
        {
            builder.HasKey(e => e.IdSeccion);

            builder.ToTable("Secciones", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.DistritosMunicipal)
                .WithMany(p => p.Secciones)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Secciones_DistritosMunicipales");
        }
    }
}