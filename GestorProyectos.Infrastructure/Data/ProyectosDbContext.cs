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

        public virtual DbSet<Barrios> Barrios { get; set; } = null!;
        public virtual DbSet<DistritosMunicipales> DistritosMunicipales { get; set; } = null!;
        public virtual DbSet<Estados> Estados { get; set; } = null!;
        public virtual DbSet<Municipios> Municipios { get; set; } = null!;
        public virtual DbSet<Provincias> Provincias { get; set; } = null!;
        public virtual DbSet<Secciones> Secciones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
