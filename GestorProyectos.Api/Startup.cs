using GestorProyectos.Core.Interfaces;
using GestorProyectos.Infrastructure.Data;
using GestorProyectos.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorProyectos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddDbContext<ProyectosDbContext>(x => { x.UseSqlServer(Configuration.GetConnectionString("ProyectosDbContext"), builder => builder.CommandTimeout((int)TimeSpan.FromMinutes(120).TotalSeconds)); }, ServiceLifetime.Scoped);
            services.AddDbContext<DBContextP>(x => { x.UseSqlServer(Configuration.GetConnectionString("DBContextP"), builder => builder.CommandTimeout((int)TimeSpan.FromMinutes(120).TotalSeconds)); }, ServiceLifetime.Scoped);
            services.AddMvc().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            AddInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void AddInjection(IServiceCollection services)
        {
            services.AddScoped<IBarriosRepository, BarriosRepository>();
            services.AddScoped<IEstadosRepository, EstadosRepository>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }
}
