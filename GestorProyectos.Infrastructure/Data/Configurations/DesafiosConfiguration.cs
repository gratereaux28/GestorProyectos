using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DesafiosConfiguration : IEntityTypeConfiguration<Desafios>
    {
        public void Configure(EntityTypeBuilder<Desafios> builder)
        {
            builder.HasKey(e => e.IdDesafio)
                    .HasName("PK__Desafios__4C42241D907D7327");

            builder.ToTable("Desafios", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }
}