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

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.FechaFinal).HasColumnType("date");

            builder.Property(e => e.FechaInicio).HasColumnType("date");

            builder.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

            builder.Property(e => e.MontoPresupuestario).HasColumnType("decimal(18, 13)");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ObjetivoEspecifico).IsUnicode(false);

            builder.Property(e => e.ObjetivoGeneral).IsUnicode(false);

            builder.Property(e => e.Resultados).IsUnicode(false);

            builder.Property(e => e.TipoMoneda)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.Aliado)
                .WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdAliado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyectos_Aliado");

            builder.HasOne(d => d.RangoBeneficiarios)
                .WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdRangoPresupuestario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyectos_RangoBeneficiario");
        }
    }
}