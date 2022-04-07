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
                .HasName("PK__Desafios__28AB2CBFB83B4B49");

            builder.ToTable("DesafiosProyectos", "Operacion");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.Desafio)
                .WithMany(p => p.DesafiosProyectos)
                .HasForeignKey(d => d.IdDesafio)
                .HasConstraintName("FK_DesafiosProyectos_Desafios");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.DesafiosProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DesafiosProyectos_Proyectos");
        }
    }
}