using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DonantesConfiguration : IEntityTypeConfiguration<Donantes>
    {
        public void Configure(EntityTypeBuilder<Donantes> builder)
        {
            builder.HasKey(e => e.IdDonante)
                .HasName("PK__Donantes__AB10528D0F9C94CC");

            builder.ToTable("Donantes", "Maestras");

            builder.Property(e => e.Direccion).IsUnicode(false);

            builder.Property(e => e.Donacion).HasColumnType("decimal(18, 12)");

            builder.Property(e => e.Identificacion)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Informacion).IsUnicode(false);

            builder.Property(e => e.Monto1).HasColumnType("decimal(23, 12)");

            builder.Property(e => e.Monto2).HasColumnType("decimal(23, 12)");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.DonantesClasificacion)
                .WithMany(p => p.Donantes)
                .HasForeignKey(d => d.IdClasificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donantes_DonantesClasificaciones");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.Donantes)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donantes_Proyectos");
        }
    }
}