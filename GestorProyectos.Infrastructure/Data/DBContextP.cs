using GestorProyectos.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestorProyectos.Infrastructure.Data
{
    public partial class DBContextP : DbContext
    {
        public DBContextP()
        {
        }

        public DBContextP(DbContextOptions<DBContextP> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(false);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DBContextP"));
            }
        }

        public virtual DbSet<WeatherForecast> WeatherForecast { get; set; }
    }
}
