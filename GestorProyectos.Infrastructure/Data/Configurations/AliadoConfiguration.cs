using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class AliadoConfiguration : IEntityTypeConfiguration<Aliado>
    {
        public void Configure(EntityTypeBuilder<Aliado> builder)
        {
            builder.HasKey(e => e.IdProyecto)
                .HasName("PK__Aliado__A593DFA86725C9C2");

            builder.ToTable("Aliado", "Maestras");

            builder.Property(e => e.IdProyecto).ValueGeneratedNever();

            builder.Property(e => e.Direccion)
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.IdAliado).ValueGeneratedOnAdd();

            builder.Property(e => e.Identificacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Informacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasOne(d => d.Clasificacion)
                .WithMany(p => p.Aliados)
                .HasForeignKey(d => d.IdClasificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aliado_Clasificaciones");

            builder.HasOne(d => d.Proyecto)
                .WithOne(p => p.Aliado)
                .HasForeignKey<Aliado>(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Aliado_Proyectos");
        }
    }
}