using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Services;
using GestorProyectos.Infrastructure.Data;
using GestorProyectos.Infrastructure.Interfaces;
using GestorProyectos.Infrastructure.Repositories;
using GestorProyectos.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GestorProyectos.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ProyectosDbContext>(x => { x.UseSqlServer(configuration.GetConnectionString("ProyectosDbContext"), builder => builder.CommandTimeout((int)TimeSpan.FromMinutes(120).TotalSeconds)); }, ServiceLifetime.Scoped);
            services.AddDbContext<DBContextP>(x => { x.UseSqlServer(configuration.GetConnectionString("DBContextP"), builder => builder.CommandTimeout((int)TimeSpan.FromMinutes(120).TotalSeconds)); }, ServiceLifetime.Scoped);

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBarriosService, BarriosService>();
            services.AddTransient<IEstadosService, EstadosService>();
            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName, string ProyectName, string Version)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc(Version, new OpenApiInfo { Title = ProyectName, Version = Version });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}