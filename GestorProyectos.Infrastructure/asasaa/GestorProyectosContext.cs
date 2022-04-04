using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class GestorProyectosContext : DbContext
    {
        public GestorProyectosContext()
        {
        }

        public GestorProyectosContext(DbContextOptions<GestorProyectosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; } = null!;
        public virtual DbSet<Aliado> Aliados { get; set; } = null!;
        public virtual DbSet<AliadoClasificacione> AliadoClasificaciones { get; set; } = null!;
        public virtual DbSet<Barrio> Barrios { get; set; } = null!;
        public virtual DbSet<Beneficiario> Beneficiarios { get; set; } = null!;
        public virtual DbSet<Desafio> Desafios { get; set; } = null!;
        public virtual DbSet<DesafiosProyecto> DesafiosProyectos { get; set; } = null!;
        public virtual DbSet<DistritosMunicipale> DistritosMunicipales { get; set; } = null!;
        public virtual DbSet<DivisionTrabajoProyecto> DivisionTrabajoProyectos { get; set; } = null!;
        public virtual DbSet<DocumentosProyecto> DocumentosProyectos { get; set; } = null!;
        public virtual DbSet<DonacionClasificacione> DonacionClasificaciones { get; set; } = null!;
        public virtual DbSet<Donante> Donantes { get; set; } = null!;
        public virtual DbSet<DonantesClasificacione> DonantesClasificaciones { get; set; } = null!;
        public virtual DbSet<Ejecucione> Ejecuciones { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<LugaresImplementacione> LugaresImplementaciones { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<NivelAcceso> NivelAccesos { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<RangoBeneficiario> RangoBeneficiarios { get; set; } = null!;
        public virtual DbSet<Seccione> Secciones { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;
        public virtual DbSet<TipoBeneficiario> TipoBeneficiarios { get; set; } = null!;
        public virtual DbSet<TiposBeneficiarioProyecto> TiposBeneficiarioProyectos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=159.89.224.57;Initial Catalog=GestorProyectos;User Id=mgratereaux;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.HasKey(e => e.IdActividad)
                    .HasName("PK_Actividades_1");

                entity.ToTable("Actividades", "Operacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actividades_Proyectos");
            });

            modelBuilder.Entity<Aliado>(entity =>
            {
                entity.HasKey(e => e.IdAliado)
                    .HasName("PK__Aliado__A593DFA86725C9C2");

                entity.ToTable("Aliado", "Maestras");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Informacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasificacionNavigation)
                    .WithMany(p => p.Aliados)
                    .HasForeignKey(d => d.IdClasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aliado_Clasificaciones");
            });

            modelBuilder.Entity<AliadoClasificacione>(entity =>
            {
                entity.HasKey(e => e.IdClasificacion)
                    .HasName("PK__Clasific__4CABC77848BAFD01");

                entity.ToTable("AliadoClasificaciones", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasKey(e => e.IdBarrio);

                entity.ToTable("Barrios", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.Barrios)
                    .HasForeignKey(d => d.IdSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Barrios_Secciones");
            });

            modelBuilder.Entity<Beneficiario>(entity =>
            {
                entity.HasKey(e => e.IdBeneficiario)
                    .HasName("PK__Benefici__3D23355F8CFAB65E");

                entity.ToTable("Beneficiarios", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Desafio>(entity =>
            {
                entity.HasKey(e => e.IdDesafio)
                    .HasName("PK__Desafios__19B32A67839D52E3");

                entity.ToTable("Desafios", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DesafiosProyecto>(entity =>
            {
                entity.HasKey(e => e.IdDesafioProyecto)
                    .HasName("PK__Desafios__28AB2CBFB83B4B49");

                entity.ToTable("DesafiosProyectos", "Operacion");

                entity.HasOne(d => d.IdDesafioNavigation)
                    .WithMany(p => p.DesafiosProyectos)
                    .HasForeignKey(d => d.IdDesafio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DesafiosProyectos_Desafios");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.DesafiosProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DesafiosProyectos_Proyectos");
            });

            modelBuilder.Entity<DistritosMunicipale>(entity =>
            {
                entity.HasKey(e => e.IdDistrito);

                entity.ToTable("DistritosMunicipales", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.DistritosMunicipales)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DistritosMunicipales_Municipios");
            });

            modelBuilder.Entity<DivisionTrabajoProyecto>(entity =>
            {
                entity.HasKey(e => e.IdDivision)
                    .HasName("PK__Division__542428D0F4EB5C55");

                entity.ToTable("DivisionTrabajoProyectos", "Operacion");

                entity.HasOne(d => d.IdNivelAccesoNavigation)
                    .WithMany(p => p.DivisionTrabajoProyectos)
                    .HasForeignKey(d => d.IdNivelAcceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DivisionTrabajoProyectos_NivelAcceso");
            });

            modelBuilder.Entity<DocumentosProyecto>(entity =>
            {
                entity.HasKey(e => e.IdDocumento)
                    .HasName("PK__Document__E52073474722F293");

                entity.ToTable("DocumentosProyecto", "Operacion");

                entity.Property(e => e.Ext)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.NombreArchivo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.DocumentosProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentosProyecto_Proyectos");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.DocumentosProyectos)
                    .HasForeignKey(d => d.IdTarea)
                    .HasConstraintName("FK_DocumentosProyecto_Tareas");
            });

            modelBuilder.Entity<DonacionClasificacione>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DonacionClasificaciones", "Maestras");

                entity.Property(e => e.IdClasificacion).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Donante>(entity =>
            {
                entity.HasKey(e => e.IdDonante)
                    .HasName("PK__Donantes__AB10528D0F9C94CC");

                entity.ToTable("Donantes", "Maestras");

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Donacion).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Informacion).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasificacionNavigation)
                    .WithMany(p => p.Donantes)
                    .HasForeignKey(d => d.IdClasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donantes__IdClas__05D8E0BE");
            });

            modelBuilder.Entity<DonantesClasificacione>(entity =>
            {
                entity.HasKey(e => e.IdClasificacion)
                    .HasName("PK__Donantes__4CABC7788C24B915");

                entity.ToTable("DonantesClasificaciones", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ejecucione>(entity =>
            {
                entity.HasKey(e => e.IdEjecucion)
                    .HasName("PK__Ejecucio__C0B1176164ECDD9F");

                entity.ToTable("Ejecuciones", "Operacion");

                entity.Property(e => e.PresupuestoEjecutado).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProyectoInpactadoId).HasColumnName("ProyectoInpactadoID");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Ejecuciones)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ejecuciones_Proyectos");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estados__FBB0EDC16CEBAA30");

                entity.ToTable("Estados", "Maestras");

                entity.Property(e => e.IdTipo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LugaresImplementacione>(entity =>
            {
                entity.HasKey(e => e.IdImplementacion)
                    .HasName("PK__LugaresI__C19263473A5F6F72");

                entity.ToTable("LugaresImplementaciones", "Operacion");

                entity.HasOne(d => d.IdBarrioNavigation)
                    .WithMany(p => p.LugaresImplementaciones)
                    .HasForeignKey(d => d.IdBarrio)
                    .HasConstraintName("FK_LugaresImplementaciones_Barrios");

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.LugaresImplementaciones)
                    .HasForeignKey(d => d.IdDistrito)
                    .HasConstraintName("FK_LugaresImplementaciones_DistritosMunicipales");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.LugaresImplementaciones)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_LugaresImplementaciones_Municipios");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.LugaresImplementaciones)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_LugaresImplementaciones_Provincias");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.LugaresImplementaciones)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_LugaresImplementaciones_Proyectos");

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.LugaresImplementaciones)
                    .HasForeignKey(d => d.IdSeccion)
                    .HasConstraintName("FK_LugaresImplementaciones_Secciones");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio);

                entity.ToTable("Municipios", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipios_Provincias");
            });

            modelBuilder.Entity<NivelAcceso>(entity =>
            {
                entity.HasKey(e => e.IdNivelAcceso)
                    .HasName("PK__NivelAcc__0C3A5FBCDBA10DC5");

                entity.ToTable("NivelAcceso", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("Provincia_PK");

                entity.ToTable("Provincias", "Maestras");

                entity.Property(e => e.IdProvincia).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK__Proyecto__F4888673943931C4");

                entity.ToTable("Proyectos", "Operacion");

                entity.Property(e => e.Codigo)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([Function].[func_Get_new_Codigo]())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaFinal).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoPresupuestario).HasColumnType("decimal(18, 13)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObjetivoEspecifico).IsUnicode(false);

                entity.Property(e => e.ObjetivoGeneral).IsUnicode(false);

                entity.Property(e => e.Resultados).IsUnicode(false);

                entity.Property(e => e.TipoMoneda)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAliadoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdAliado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proyectos_Aliado");

                entity.HasOne(d => d.IdRangoPresupuestarioNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdRangoPresupuestario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proyectos_RangoBeneficiario");
            });

            modelBuilder.Entity<RangoBeneficiario>(entity =>
            {
                entity.HasKey(e => e.IdRango)
                    .HasName("PK__RangoBen__B9E65D7F67680211");

                entity.ToTable("RangoBeneficiario", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seccione>(entity =>
            {
                entity.HasKey(e => e.IdSeccion);

                entity.ToTable("Secciones", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDistritoNavigation)
                    .WithMany(p => p.Secciones)
                    .HasForeignKey(d => d.IdDistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secciones_DistritosMunicipales");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK__Tareas__EADE9098645F0EAF");

                entity.ToTable("Tareas", "Operacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaFinal).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.HasOne(d => d.IdActividadNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tareas_Actividades");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tareas_Estados");

                entity.HasOne(d => d.IdResponsableNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdResponsable)
                    .HasConstraintName("FK_Tareas_Usuarios");
            });

            modelBuilder.Entity<TipoBeneficiario>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TipoBene__9E3A29A5D8A6E64A");

                entity.ToTable("TipoBeneficiario", "Maestras");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposBeneficiarioProyecto>(entity =>
            {
                entity.HasKey(e => e.IdTipoBeneficiarioProyecto)
                    .HasName("PK__TiposBen__A415AEF400978EE1");

                entity.ToTable("TiposBeneficiarioProyecto", "Operacion");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.TiposBeneficiarioProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TiposBeneficiarioProyecto_Proyectos");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.TiposBeneficiarioProyectos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TiposBeneficiarioProyecto_TipoBeneficiario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF975744D197");

                entity.ToTable("Usuarios", "Maestras");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
