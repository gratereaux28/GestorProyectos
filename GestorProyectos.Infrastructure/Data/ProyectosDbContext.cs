using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace GestorProyectos.Infrastructure.Data
{
    public partial class ProyectosDbContext : DbContext
    {
        public ProyectosDbContext()
        {
        }

        public ProyectosDbContext(DbContextOptions<ProyectosDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(false);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ProyectosDbContext"));
            }
        }
        public virtual DbSet<Actividades> Actividades { get; set; } = null!;
        public virtual DbSet<Aliado> Aliado { get; set; } = null!;
        public virtual DbSet<AliadoClasificaciones> AliadoClasificaciones { get; set; } = null!;
        public virtual DbSet<Barrios> Barrios { get; set; } = null!;
        public virtual DbSet<Beneficiarios> Beneficiarios { get; set; } = null!;
        public virtual DbSet<Desafios> Desafios { get; set; } = null!;
        public virtual DbSet<DesafiosProyectos> DesafiosProyectos { get; set; } = null!;
        public virtual DbSet<DistritosMunicipales> DistritosMunicipales { get; set; } = null!;
        public virtual DbSet<DivisionTrabajoProyectos> DivisionTrabajoProyectos { get; set; } = null!;
        public virtual DbSet<DocumentosProyectos> DocumentosProyectos { get; set; } = null!;
        public virtual DbSet<Donacion> Donacion { get; set; } = null!;
        public virtual DbSet<DonacionClasificaciones> DonacionClasificaciones { get; set; } = null!;
        public virtual DbSet<Donantes> Donantes { get; set; } = null!;
        public virtual DbSet<DonantesClasificaciones> DonantesClasificaciones { get; set; } = null!;
        public virtual DbSet<Ejecuciones> Ejecuciones { get; set; } = null!;
        public virtual DbSet<Estados> Estados { get; set; } = null!;
        public virtual DbSet<LugaresImplementaciones> LugaresImplementaciones { get; set; } = null!;
        public virtual DbSet<Municipios> Municipios { get; set; } = null!;
        public virtual DbSet<NivelAcceso> NivelAcceso { get; set; } = null!;
        public virtual DbSet<Provincias> Provincias { get; set; } = null!;
        public virtual DbSet<Proyectos> Proyectos { get; set; } = null!;
        public virtual DbSet<RangoBeneficiarios> RangoBeneficiarios { get; set; } = null!;
        public virtual DbSet<RangoPresupuestario> RangoPresupuestario { get; set; } = null!;
        public virtual DbSet<Secciones> Secciones { get; set; } = null!;
        public virtual DbSet<Tareas> Tareas { get; set; } = null!;
        public virtual DbSet<TipoBeneficiario> TipoBeneficiarios { get; set; } = null!;
        public virtual DbSet<TiposBeneficiarioProyecto> TiposBeneficiarioProyectos { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
