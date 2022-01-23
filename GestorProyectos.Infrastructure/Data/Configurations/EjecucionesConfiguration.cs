using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class EjecucionesConfiguration : IEntityTypeConfiguration<Ejecuciones>
    {
        public void Configure(EntityTypeBuilder<Ejecuciones> builder)
        {
            builder.HasKey(e => e.IdEjecucion)
                .HasName("PK__Ejecucio__C0B1176193F53144");

            builder.ToTable("Ejecuciones", "Operacion");

            builder.Property(e => e.PresupuestoEjecutado).HasColumnType("decimal(18, 0)");

            builder.Property(e => e.ProyectoInpactadoId).HasColumnName("ProyectoInpactadoID");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.Ejecuciones)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ejecuciones_Proyectos");
        }
    }
}