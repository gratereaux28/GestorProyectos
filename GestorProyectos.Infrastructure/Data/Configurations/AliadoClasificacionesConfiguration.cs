using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class AliadoClasificacionesConfiguration : IEntityTypeConfiguration<AliadoClasificaciones>
    {
        public void Configure(EntityTypeBuilder<AliadoClasificaciones> builder)
        {
            builder.HasKey(e => e.IdClasificacion)
                .HasName("PK__Clasific__4CABC77848BAFD01");

            builder.ToTable("AliadoClasificaciones", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}