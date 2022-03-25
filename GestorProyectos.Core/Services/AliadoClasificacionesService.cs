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
    public class AliadoClasificacionesService : IAliadoClasificacionesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public AliadoClasificacionesService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<AliadoClasificaciones> ObtenerClasificacion(int IdClasificacion)
        {
            var query = await _unitOfWork.AliadoClasificacionesRepository.GetAsync(e => e.IdClasificacion == IdClasificacion);
            var AliadoClasificaciones = query.FirstOrDefault();
            return AliadoClasificaciones;
        }

        public async Task<IEnumerable<AliadoClasificaciones>> ObtenerClasificacion(AliadoClasificacionesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdClasificacion != null && filters.IdClasificacion != 0)
            {
                Expression<Func<AliadoClasificaciones, bool>> query = (e => e.IdClasificacion == filters.IdClasificacion);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<AliadoClasificaciones, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.AliadoClasificacionesRepository.GetAsync(expressions);
            return data;
        }

        public async Task<AliadoClasificaciones> AgregarClasificacion(AliadoClasificaciones clasificacion)
        {
            clasificacion.IdClasificacion = 0;
            return await _unitOfWork.AliadoClasificacionesRepository.AddAsync(clasificacion);
        }

        public async Task<bool> ActualizarClasificacion(AliadoClasificaciones clasificacion)
        {
            var aliado = await ObtenerClasificacion(clasificacion.IdClasificacion);
            if (aliado != null)
            {
                clasificacion.CopyTo(aliado);
                _unitOfWork.AliadoClasificacionesRepository.UpdateNoSave(aliado);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarAliadoClasificaciones(int IdClasificacion)
        {
            var aliado = await ObtenerClasificacion(IdClasificacion);
            if (aliado != null)
            {
                _unitOfWork.AliadoClasificacionesRepository.DeleteNoSave(aliado);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}