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
    public class RangoPresupuestarioService : IRangoPresupuestarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public RangoPresupuestarioService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<RangoPresupuestario> ObtenerRango(int IdRango)
        {
            var query = await _unitOfWork.RangoPresupuestarioRepository.GetAsync(e => e.IdRango == IdRango);
            var rango = query.FirstOrDefault();
            return rango;
        }

        public async Task<IEnumerable<RangoPresupuestario>> ObtenerRango(RangoPresupuestarioQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdRango != null && filters.IdRango != 0)
            {
                Expression<Func<RangoPresupuestario, bool>> query = (e => e.IdRango == filters.IdRango);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<RangoPresupuestario, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.RangoPresupuestarioRepository.GetAsync(expressions);
            return data;
        }

        public async Task<RangoPresupuestario> AgregarRango(RangoPresupuestario rango)
        {
            rango.IdRango = 0;
            return await _unitOfWork.RangoPresupuestarioRepository.AddAsync(rango);
        }

        public async Task<bool> ActualizarRango(RangoPresupuestario rango)
        {
            var Rango = await ObtenerRango(rango.IdRango);
            if (Rango != null)
            {
                rango.CopyTo(Rango);
                _unitOfWork.RangoPresupuestarioRepository.UpdateNoSave(Rango);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarRangoPresupuestario(int IdRango)
        {
            var rango = await ObtenerRango(IdRango);
            if (rango != null)
            {
                _unitOfWork.RangoPresupuestarioRepository.DeleteNoSave(rango);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}