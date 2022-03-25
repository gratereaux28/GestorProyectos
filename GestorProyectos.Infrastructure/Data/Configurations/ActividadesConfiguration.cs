using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class ActividadesConfiguration : IEntityTypeConfiguration<Actividades>
    {
        public void Configure(EntityTypeBuilder<Actividades> builder)
        {
            builder.HasKey(e => e.IdActividad)
                .HasName("PK_Actividades_1");

            builder.ToTable("Actividades", "Operacion");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.Actividades)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Actividades_Proyectos");
        }
    }
}