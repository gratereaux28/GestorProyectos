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

        public async Task<Barrios> ObtenerBarrio(int IdBarrio)
        {
            var query = await _unitOfWork.BarriosRepository.GetAsync(e => e.IdBarrio == IdBarrio);
            var Barrio = query.FirstOrDefault();
            return Barrio;
        }

        public async Task<IEnumerable<Barrios>> ObtenerBarrios(BarriosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdBarrio != null && filters.IdBarrio != 0)
            {
                Expression<Func<Barrios, bool>> query = (e => e.IdBarrio == filters.IdBarrio);
                expressions.Add(query);
            }
            if (filters.IdSeccion != null && filters.IdSeccion != 0)
            {
                Expression<Func<Barrios, bool>> query = (e => e.IdSeccion == filters.IdSeccion);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Barrios, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var repo = _unitOfWork.BarriosRepository;
            //repo.AddInclude("Seccion");
            var data = await repo.GetAsync(expressions);
            return data;
        }
    }
}