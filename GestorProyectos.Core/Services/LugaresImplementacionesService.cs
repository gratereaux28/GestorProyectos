using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class LugaresImplementacionesService : ILugaresImplementacionesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LugaresImplementacionesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LugaresImplementaciones> ObtenerImplementacion(int IdImplementacion)
        {
            var query = await _unitOfWork.LugaresImplementacionesRepository.GetAsync(e => e.IdImplementacion == IdImplementacion);
            var Implementacion = query.FirstOrDefault();
            return Implementacion;
        }

        public async Task<IEnumerable<LugaresImplementaciones>> ObtenerLugaresImplementaciones(LugaresImplementacionesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdImplementacion != null && filters.IdImplementacion != 0)
            {
                Expression<Func<LugaresImplementaciones, bool>> query = (e => e.IdImplementacion == filters.IdImplementacion);
                expressions.Add(query);
            }
            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<LugaresImplementaciones, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
                expressions.Add(query);
            }
            if (filters.IdProvincia != null && filters.IdProvincia != 0)
            {
                Expression<Func<LugaresImplementaciones, bool>> query = (e => e.IdProvincia == filters.IdProvincia);
                expressions.Add(query);
            }

            var data = await _unitOfWork.LugaresImplementacionesRepository.GetAsync(expressions);
            return data;
        }

        public async Task<LugaresImplementaciones> AgregarImplementacion(LugaresImplementaciones implementacion)
        {
            implementacion.IdImplementacion = 0;
            return await _unitOfWork.LugaresImplementacionesRepository.AddAsync(implementacion);
        }

        public async Task<bool> ActualizarImplementacion(LugaresImplementaciones implementacion)
        {
            var Implementacion = await ObtenerImplementacion(implementacion.IdImplementacion);
            if (Implementacion != null)
            {
                implementacion.CopyTo(Implementacion);
                _unitOfWork.LugaresImplementacionesRepository.UpdateNoSave(Implementacion);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarImplementacion(int IdImplementacion)
        {
            var Implementacion = await ObtenerImplementacion(IdImplementacion);
            if (Implementacion != null)
            {
                _unitOfWork.LugaresImplementacionesRepository.DeleteNoSave(Implementacion);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}