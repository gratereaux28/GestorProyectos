using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DonantesConfiguration : IEntityTypeConfiguration<Donantes>
    {
        public void Configure(EntityTypeBuilder<Donantes> builder)
        {
            builder.HasKey(e => e.IdDonante);

            builder.ToTable("Donantes", "Maestras");

            builder.HasIndex(e => e.IdProyecto, "IX_Donantes_IdProyecto")
                .IsUnique();

            builder.Property(e => e.Direccion).IsUnicode(false);

            builder.Property(e => e.Identificacion)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Informacion).IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.DonantesClasificacion)
                .WithMany(p => p.Donantes)
                .HasForeignKey(d => d.IdClasificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donantes_DonantesClasificaciones");

            builder.HasOne(d => d.Proyecto)
                .WithOne(p => p.Donante)
                .HasForeignKey<Donantes>(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donantes_Proyectos");
        }
    }
}