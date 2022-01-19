using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class EstadosConfiguration : IEntityTypeConfiguration<Estados>
    {
        public void Configure(EntityTypeBuilder<Estados> builder)
        {
            builder.HasKey(e => e.IdEstado);

            builder.ToTable("Estados", "Maestras");

            builder.Property(e => e.IdTipo)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
