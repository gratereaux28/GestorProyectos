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
            //services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBarriosService, BarriosService>();
            services.AddTransient<IBeneficiariosService, BeneficiariosService>();
            services.AddTransient<IDesafiosProyectosService, DesafiosProyectosService>();
            services.AddTransient<IDesafiosService, DesafiosService>();
            services.AddTransient<IDistritosMunicipalesService, DistritosMunicipalesService>();
            services.AddTransient<IDocumentosProyectosService, DocumentosProyectosService>();
            services.AddTransient<IEjecucionesService, EjecucionesService>();
            services.AddTransient<IEstadosService, EstadosService>();
            services.AddTransient<ILugaresImplementacionesService, LugaresImplementacionesService>();
            services.AddTransient<IMunicipiosService, MunicipiosService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IProvinciasService, ProvinciasService>();
            services.AddTransient<IProyectosService, ProyectosService>();
            services.AddTransient<ISeccionesService, SeccionesService>();
            services.AddTransient<ITareasService, TareasService>();
            services.AddTransient<ITerritoriosImpactadosService, TerritoriosImpactadosService>();
            services.AddTransient<IUsuariosService, UsuariosService>();
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

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName, string ProyectName, string Version, string Description, string CompanyUrl)
        {
            services.AddSwaggerGen(options =>
            {
                //doc.SwaggerDoc(Version, new OpenApiInfo { Title = ProyectName, Version = Version });

                options.SwaggerDoc(Version, new OpenApiInfo
                {
                    Title = ProyectName,
                    Version = Version,
                    Description = Description,
                    TermsOfService = new Uri(CompanyUrl),
                    Contact = new OpenApiContact
                    {
                        Name = "Company Name",
                        Email = "info@email.com",
                        Url = new Uri(CompanyUrl),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Swagger Implementation License",
                        Url = new Uri(CompanyUrl),
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. <br>
                      Enter 'Bearer' [space] and then your token in the text input below.
                      <br> Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                  {
                    new OpenApiSecurityScheme
                    {
                      Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                      },
                      new List<string>()
                    }
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}