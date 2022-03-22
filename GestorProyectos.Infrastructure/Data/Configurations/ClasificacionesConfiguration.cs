using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class ClasificacionesConfiguration : IEntityTypeConfiguration<Clasificaciones>
    {
        public void Configure(EntityTypeBuilder<Clasificaciones> builder)
        {
            builder.HasKey(e => e.IdClasificacion)
                .HasName("PK__Clasific__4CABC77848BAFD01");

            builder.ToTable("Clasificaciones", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}