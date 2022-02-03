using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DocumentosProyectoConfiguration : IEntityTypeConfiguration<DocumentosProyectos>
    {
        public void Configure(EntityTypeBuilder<DocumentosProyectos> builder)
        {
            builder.HasKey(e => e.IdDocumento)
                .HasName("PK__Document__E520734772EE3538");

            builder.ToTable("DocumentosProyecto", "Operacion");

            builder.Property(e => e.Ext)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Fecha).HasColumnType("date");

            builder.Property(e => e.NombreArchivo)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("URL");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.DocumentosProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DocumentosProyecto_Proyectos");

            builder.HasOne(d => d.Tarea)
                .WithMany(p => p.DocumentosProyectos)
                .HasForeignKey(d => d.IdTarea)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DocumentosProyecto_Tareas");
        }
    }
}