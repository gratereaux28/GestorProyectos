﻿using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorProyectos.Infrastructure.Data.Configurations
{
    public class TiposBeneficiarioProyectoConfiguration : IEntityTypeConfiguration<TiposBeneficiarioProyecto>
    {
        public void Configure(EntityTypeBuilder<TiposBeneficiarioProyecto> builder)
        {
            builder.HasKey(e => e.IdTipoBeneficiarioProyecto)
                .HasName("PK__TiposBen__A415AEF400978EE1");

            builder.ToTable("TiposBeneficiarioProyecto", "Operacion");

            builder.HasOne(d => d.Proyecto)
                .WithMany(p => p.TiposBeneficiarioProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TiposBeneficiarioProyecto_Proyectos");

            builder.HasOne(d => d.TipoBeneficiario)
                .WithMany(p => p.TiposBeneficiarioProyectos)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TiposBeneficiarioProyecto_TipoBeneficiario");
        }
    }
}