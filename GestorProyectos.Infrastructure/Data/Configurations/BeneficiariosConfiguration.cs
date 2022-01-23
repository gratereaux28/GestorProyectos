using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class BeneficiariosConfiguration : IEntityTypeConfiguration<Beneficiarios>
    {
        public void Configure(EntityTypeBuilder<Beneficiarios> builder)
        {
            builder.HasKey(e => e.IdBeneficiario)
                   .HasName("PK__Benefici__5A04A8D3A238897A");

            builder.ToTable("Beneficiarios", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}