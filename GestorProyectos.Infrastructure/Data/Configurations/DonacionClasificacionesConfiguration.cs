using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DonacionClasificacionesConfiguration : IEntityTypeConfiguration<DonacionClasificaciones>
    {
        public void Configure(EntityTypeBuilder<DonacionClasificaciones> builder)
        {
            builder.HasNoKey();

            builder.ToTable("DonacionClasificaciones", "Maestras");

            builder.Property(e => e.IdClasificacion).ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}