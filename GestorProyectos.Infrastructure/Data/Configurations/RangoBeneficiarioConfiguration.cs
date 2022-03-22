using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class RangoBeneficiariosConfiguration : IEntityTypeConfiguration<RangoBeneficiarios>
    {
        public void Configure(EntityTypeBuilder<RangoBeneficiarios> builder)
        {
            builder.HasKey(e => e.IdRango)
                .HasName("PK__RangoBen__B9E65D7F67680211");

            builder.ToTable("RangoBeneficiario", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}