using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class SeccionesService : ISeccionesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeccionesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Secciones> ObtenerSeccion(int IdSeccion)
        {
            var query = await _unitOfWork.SeccionesRepository.GetAsync(e => e.IdSeccion == IdSeccion);
            var Seccion = query.FirstOrDefault();
            return Seccion;
        }

        public async Task<IEnumerable<Secciones>> ObtenerSecciones(SeccionesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdSeccion != null && filters.IdSeccion != 0)
            {
                Expression<Func<Secciones, bool>> query = (e => e.IdSeccion == filters.IdSeccion);
                expressions.Add(query);
            }
            if (filters.IdDistrito != null && filters.IdDistrito != 0)
            {
                Expression<Func<Secciones, bool>> query = (e => e.IdDistrito == filters.IdDistrito);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Secciones, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }
            if (filters.IdsDistrito != null && filters.IdsDistrito.Count() > 0)
            {
                Expression<Func<Secciones, bool>> query = (e => filters.IdsDistrito.Contains(e.IdDistrito));
                expressions.Add(query);
            }
            if (filters.Nombres != null && filters.Nombres.Count() > 0)
            {
                Expression<Func<Secciones, bool>> query = (e => filters.Nombres.Select(n => n.ToLower()).Contains(e.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.SeccionesRepository.GetAsync(expressions);
            return data;
        }
    }
}