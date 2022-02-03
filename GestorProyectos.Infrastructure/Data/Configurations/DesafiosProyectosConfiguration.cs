using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DesafiosProyectosConfiguration : IEntityTypeConfiguration<DesafiosProyectos>
    {
        public void Configure(EntityTypeBuilder<DesafiosProyectos> builder)
        {
            builder.HasKey(e => e.IdDesafioProyecto)
                .HasName("PK__Desafios__19B32A6788064FAD");

            builder.ToTable("DesafiosProyectos", "Operacion");

            builder.HasOne(d => d.Desafio)
                .WithMany(p => p.DesafiosProyectos)
                .HasForeignKey(d => d.IdDesafio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DesafiosProyectos_Desafios");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.DesafiosProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DesafiosProyectos_Proyectos");
        }
    }
}