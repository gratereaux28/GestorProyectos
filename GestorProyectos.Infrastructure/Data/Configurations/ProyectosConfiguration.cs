using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class ProyectosConfiguration : IEntityTypeConfiguration<Proyectos>
    {
        public void Configure(EntityTypeBuilder<Proyectos> builder)
        {
            builder.HasKey(e => e.IdProyecto)
                .HasName("PK__Proyecto__F4888673943931C4");

            builder.ToTable("Proyectos", "Operacion");

            builder.Property(e => e.Codigo)
                .IsUnicode(false)
                .HasDefaultValueSql("([Function].[func_Get_new_Codigo]())");

            builder.Property(e => e.DatosBeneficiario).IsUnicode(false);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DescripcionEspecie).IsUnicode(false);

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.FechaFinal).HasColumnType("date");

            builder.Property(e => e.FechaInicio).HasColumnType("date");

            builder.Property(e => e.IdTipoBeneficiario)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.IdTipoPresupuesto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.RangoPresupuestado).HasColumnType("decimal(23, 12)");

            builder.Property(e => e.TipoMoneda)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}