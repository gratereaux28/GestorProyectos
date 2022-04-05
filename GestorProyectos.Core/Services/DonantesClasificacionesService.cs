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
    public class DonantesClasificacionesService : IDonantesClasificacionesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public DonantesClasificacionesService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<DonantesClasificaciones> ObtenerClasificacion(int IdClasificacion)
        {
            var query = await _unitOfWork.DonantesClasificacionesRepository.GetAsync(e => e.IdClasificacion == IdClasificacion);
            var clasificacion = query.FirstOrDefault();
            return clasificacion;
        }

        public async Task<IEnumerable<DonantesClasificaciones>> ObtenerClasificacion(DonantesClasificacionesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdClasificacion != null && filters.IdClasificacion != 0)
            {
                Expression<Func<DonantesClasificaciones, bool>> query = (e => e.IdClasificacion == filters.IdClasificacion);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<DonantesClasificaciones, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.DonantesClasificacionesRepository.GetAsync(expressions);
            return data;
        }

        public async Task<DonantesClasificaciones> AgregarClasificacion(DonantesClasificaciones clasificacion)
        {
            clasificacion.IdClasificacion = 0;
            return await _unitOfWork.DonantesClasificacionesRepository.AddAsync(clasificacion);
        }

        public async Task<bool> ActualizarClasificacion(DonantesClasificaciones clasificacion)
        {
            var Clasificacion = await ObtenerClasificacion(clasificacion.IdClasificacion);
            if (Clasificacion != null)
            {
                clasificacion.CopyTo(Clasificacion);
                _unitOfWork.DonantesClasificacionesRepository.UpdateNoSave(Clasificacion);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarDonantesClasificaciones(int IdClasificacion)
        {
            var clasificacion = await ObtenerClasificacion(IdClasificacion);
            if (clasificacion != null)
            {
                _unitOfWork.DonantesClasificacionesRepository.DeleteNoSave(clasificacion);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}