using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(e => e.IdUsuario);

            builder.ToTable("Usuarios", "Maestras");

            builder.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Apellido)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Correo)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Usuario)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Clave)
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}