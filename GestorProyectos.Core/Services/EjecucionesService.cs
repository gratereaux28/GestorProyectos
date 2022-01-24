using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class EjecucionesService : IEjecucionesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EjecucionesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ejecuciones> ObtenerEjecucion(int IdEjecucion)
        {
            var query = await _unitOfWork.EjecucionesRepository.GetAsync(e => e.IdEjecucion == IdEjecucion);
            var Ejecucion = query.FirstOrDefault();
            return Ejecucion;
        }

        public async Task<IEnumerable<Ejecuciones>> ObtenerEjecuciones(EjecucionesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdEjecucion != null && filters.IdEjecucion != 0)
            {
                Expression<Func<Ejecuciones, bool>> query = (e => e.IdEjecucion == filters.IdEjecucion);
                expressions.Add(query);
            }
            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<Ejecuciones, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
                expressions.Add(query);
            }

            var data = await _unitOfWork.EjecucionesRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Ejecuciones> AgregarEjecucion(Ejecuciones ejecucion)
        {
            ejecucion.IdEjecucion = 0;
            return await _unitOfWork.EjecucionesRepository.AddAsync(ejecucion);
        }

        public async Task<bool> ActualizarEjecucion(Ejecuciones ejecucion)
        {
            var Ejecucion = await ObtenerEjecucion(ejecucion.IdEjecucion);
            if (Ejecucion != null)
            {
                ejecucion.CopyTo(Ejecucion);
                _unitOfWork.EjecucionesRepository.UpdateNoSave(Ejecucion);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarEjecucion(int IdEjecucion)
        {
            var Ejecucion = await ObtenerEjecucion(IdEjecucion);
            if (Ejecucion != null)
            {
                _unitOfWork.EjecucionesRepository.DeleteNoSave(Ejecucion);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}