using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class LugaresImplementacionesConfiguration : IEntityTypeConfiguration<LugaresImplementaciones>
    {
        public void Configure(EntityTypeBuilder<LugaresImplementaciones> builder)
        {
            builder.HasKey(e => e.IdImplementacion)
                .HasName("PK__LugaresI__C19263476509F9F2");

            builder.ToTable("LugaresImplementaciones", "Operacion");

            builder.HasOne(d => d.Provincia)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LugaresImplementaciones_Provincias");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LugaresImplementaciones_Proyectos");
        }
    }
}