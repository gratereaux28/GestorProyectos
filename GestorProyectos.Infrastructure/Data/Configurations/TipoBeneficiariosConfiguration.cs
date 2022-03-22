using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class TipoBeneficiarioConfiguration : IEntityTypeConfiguration<TipoBeneficiario>
    {
        public void Configure(EntityTypeBuilder<TipoBeneficiario> builder)
        {
            builder.HasKey(e => e.IdTipo)
                .HasName("PK__TipoBene__9E3A29A5D8A6E64A");

            builder.ToTable("TipoBeneficiario", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}