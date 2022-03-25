using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Exceptions;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class ActividadesService : IActividadesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public ActividadesService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<Actividades> ObtenerActividad(int IdActividad)
        {
            var query = await _unitOfWork.ActividadesRepository.AddInclude("Tareas").GetAsync(e => e.IdActividad == IdActividad);
            var Actividades = query.FirstOrDefault();
            return Actividades;
        }

        public async Task<IEnumerable<Actividades>> ObtenerActividad(ActividadesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdActividad != null && filters.IdActividad != 0)
            {
                Expression<Func<Actividades, bool>> query = (e => e.IdActividad == filters.IdActividad);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Descripcion))
            {
                Expression<Func<Actividades, bool>> query = (e => e.Descripcion.ToLower().Contains(filters.Descripcion.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.ActividadesRepository.AddInclude("Tareas").GetAsync(expressions);
            return data;
        }

        public async Task<Actividades> AgregarActividad(Actividades Actividad)
        {
            Actividad.IdActividad = 0;
            return await _unitOfWork.ActividadesRepository.AddAsync(Actividad);
        }

        public async Task<bool> ActualizarActividad(Actividades actividad)
        {
            var Actividad = await ObtenerActividad(actividad.IdActividad);
            if (Actividad != null)
            {
                actividad.CopyTo(Actividad);
                _unitOfWork.ActividadesRepository.UpdateNoSave(Actividad);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarActividades(int IdActividad)
        {
            var actividad = await ObtenerActividad(IdActividad);
            if (actividad != null)
            {
                _unitOfWork.ActividadesRepository.DeleteNoSave(actividad);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}