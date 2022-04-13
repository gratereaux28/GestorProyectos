using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class RangoPresupuestarioConfiguration : IEntityTypeConfiguration<RangoPresupuestario>
    {
        public void Configure(EntityTypeBuilder<RangoPresupuestario> builder)
        {
            builder.HasKey(e => e.IdRango)
                .HasName("PK__RangoPre__B9E65D7F67680211");

            builder.ToTable("RangoPresupuestario", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}