using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class BarriosService : IBarriosService
    {

        private readonly IUnitOfWork _unitOfWork;

        public BarriosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Barrios>> ObtenerBarrios(BarriosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdBarrio != null)
            {
                Expression<Func<Barrios, bool>> query = (e => e.IdBarrio == filters.IdBarrio);
                expressions.Add(query);
            }
            if (filters.IdSeccion != null)
            {
                Expression<Func<Barrios, bool>> query = (e => e.IdSeccion == filters.IdSeccion);
                expressions.Add(query);
            }
            if (filters.Nombre != null)
            {
                Expression<Func<Barrios, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.BarriosRepository.GetAsync(expressions);

            var pagedBarrios = PagedList<Barrios>.Create(data, filters.pageNumber, filters.pageSize);
            return pagedBarrios;
        }
    }
}