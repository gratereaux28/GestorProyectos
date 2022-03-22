using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class LugaresImplementacionesConfiguration : IEntityTypeConfiguration<LugaresImplementaciones>
    {
        public void Configure(EntityTypeBuilder<LugaresImplementaciones> builder)
        {
            builder.HasKey(e => e.IdImplementacion)
                .HasName("PK__LugaresI__C19263473A5F6F72");

            builder.ToTable("LugaresImplementaciones", "Operacion");

            builder.HasOne(d => d.Barrio)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdBarrio)
                .HasConstraintName("FK_LugaresImplementaciones_Barrios");

            builder.HasOne(d => d.DistritosMunicipal)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdDistrito)
                .HasConstraintName("FK_LugaresImplementaciones_DistritosMunicipales");

            builder.HasOne(d => d.Municipio)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK_LugaresImplementaciones_Municipios");

            builder.HasOne(d => d.Provincia)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("FK_LugaresImplementaciones_Provincias");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK_LugaresImplementaciones_Proyectos");

            builder.HasOne(d => d.Seccion)
                .WithMany(p => p.LugaresImplementaciones)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK_LugaresImplementaciones_Secciones");
        }
    }
}