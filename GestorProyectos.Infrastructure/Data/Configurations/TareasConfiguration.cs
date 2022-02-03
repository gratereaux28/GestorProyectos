using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class TareasConfiguration : IEntityTypeConfiguration<Tareas>
    {
        public void Configure(EntityTypeBuilder<Tareas> builder)
        {
            builder.HasKey(e => e.IdTarea)
                .HasName("PK__Tareas__EADE9098435C7E05");

            builder.ToTable("Tareas", "Operacion");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.FechaFinal).HasColumnType("date");

            builder.Property(e => e.FechaInicio).HasColumnType("date");

            builder.HasOne(d => d.Estado)
                .WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tareas_Estados");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tareas_Proyectos");
        }
    }
}