using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DonacionConfiguration : IEntityTypeConfiguration<Donacion>
    {
        public void Configure(EntityTypeBuilder<Donacion> builder)
        {
            builder.HasKey(e => e.IdDonacion);

            builder.ToTable("Donacion", "Maestras");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.MontoDOP)
                .HasColumnType("decimal(23, 12)")
                .HasColumnName("MontoDOP");

            builder.Property(e => e.MontoUSD)
                .HasColumnType("decimal(23, 12)")
                .HasColumnName("MontoUSD");

            builder.HasOne(d => d.DonacionClasificacion)
                .WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.IdClasificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donacion_DonacionClasificaciones");

            builder.HasOne(d => d.Donante)
                .WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.IdDonante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donacion_Donantes");
        }
    }
}