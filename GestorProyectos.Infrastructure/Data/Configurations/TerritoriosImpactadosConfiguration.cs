using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class TerritoriosImpactadosConfiguration : IEntityTypeConfiguration<TerritoriosImpactados>
    {
        public void Configure(EntityTypeBuilder<TerritoriosImpactados> builder)
        {
            builder.HasKey(e => e.IdImpacto)
                .HasName("PK__Territor__5343B38B815C1C5E");

            builder.ToTable("TerritoriosImpactados", "Operacion");

            builder.HasOne(d => d.Barrio)
                .WithMany(p => p.TerritoriosImpactados)
                .HasForeignKey(d => d.IdBarrio)
                .HasConstraintName("FK_TerritoriosImpactados_Barrios");

            builder.HasOne(d => d.Municipio)
                .WithMany(p => p.TerritoriosImpactados)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_TerritoriosImpactados_Municipios");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.TerritoriosImpactados)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TerritoriosImpactados_Proyectos");
        }
    }
}