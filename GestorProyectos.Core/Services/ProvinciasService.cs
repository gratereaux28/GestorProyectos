using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class ProvinciasService : IProvinciasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProvinciasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Provincias> ObtenerProvincia(int IdProvincia)
        {
            var query = await _unitOfWork.ProvinciasRepository.GetAsync(e => e.IdProvincia == IdProvincia);
            var Provincia = query.FirstOrDefault();
            return Provincia;
        }

        public async Task<IEnumerable<Provincias>> ObtenerProvincias(ProvinciasQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdProvincia != null && filters.IdProvincia != 0)
            {
                Expression<Func<Provincias, bool>> query = (e => e.IdProvincia == filters.IdProvincia);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Provincias, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.ProvinciasRepository.GetAsync(expressions);
            return data;
        }
    }
}