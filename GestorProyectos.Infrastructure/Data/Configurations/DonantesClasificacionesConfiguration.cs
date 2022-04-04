using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DonantesClasificacionesConfiguration : IEntityTypeConfiguration<DonantesClasificaciones>
    {
        public void Configure(EntityTypeBuilder<DonantesClasificaciones> builder)
        {
            builder.HasKey(e => e.IdClasificacion)
                .HasName("PK__Donantes__4CABC7788C24B915");

            builder.ToTable("DonantesClasificaciones", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}