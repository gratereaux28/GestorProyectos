using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class BarriosConfiguration : IEntityTypeConfiguration<Barrios>
    {
        public void Configure(EntityTypeBuilder<Barrios> builder)
        {
            builder.HasKey(e => e.IdBarrio);

            builder.ToTable("Barrios", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.Secciones)
                .WithMany(p => p.Barrios)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Barrios_Secciones");
        }
    }
}
