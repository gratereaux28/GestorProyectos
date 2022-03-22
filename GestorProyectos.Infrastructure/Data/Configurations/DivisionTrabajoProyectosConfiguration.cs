using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class DivisionTrabajoProyectosConfiguration : IEntityTypeConfiguration<DivisionTrabajoProyectos>
    {
        public void Configure(EntityTypeBuilder<DivisionTrabajoProyectos> builder)
        {
            builder.HasKey(e => e.IdDivision)
                .HasName("PK__Division__542428D0F4EB5C55");

            builder.ToTable("DivisionTrabajoProyectos", "Operacion");

            builder.HasOne(d => d.NivelAcceso)
                .WithMany(p => p.DivisionTrabajoProyectos)
                .HasForeignKey(d => d.IdNivelAcceso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DivisionTrabajoProyectos_NivelAcceso");
        }
    }
}