using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuariosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuarios> ObtenerEjecucion(int IdEjecucion)
        {
            var query = await _unitOfWork.UsuariosRepository.GetAsync(e => e.IdEjecucion == IdEjecucion);
            var Ejecucion = query.FirstOrDefault();
            return Ejecucion;
        }

        public async Task<IEnumerable<Usuarios>> ObtenerUsuarios(UsuariosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdEjecucion != null && filters.IdEjecucion != 0)
            {
                Expression<Func<Usuarios, bool>> query = (e => e.IdEjecucion == filters.IdEjecucion);
                expressions.Add(query);
            }
            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<Usuarios, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
                expressions.Add(query);
            }

            var data = await _unitOfWork.UsuariosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Usuarios> AgregarEjecucion(Usuarios ejecucion)
        {
            ejecucion.IdEjecucion = 0;
            return await _unitOfWork.UsuariosRepository.AddAsync(ejecucion);
        }

        public async Task<bool> ActualizarEjecucion(Usuarios ejecucion)
        {
            var Ejecucion = await ObtenerEjecucion(ejecucion.IdEjecucion);
            if (Ejecucion != null)
            {
                ejecucion.CopyTo(Ejecucion);
                _unitOfWork.UsuariosRepository.UpdateNoSave(Ejecucion);
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
                _unitOfWork.UsuariosRepository.DeleteNoSave(Ejecucion);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}