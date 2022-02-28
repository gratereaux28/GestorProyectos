using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class MunicipiosService : IMunicipiosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MunicipiosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Municipios> ObtenerMunicipio(int IdMunicipio)
        {
            var query = await _unitOfWork.MunicipiosRepository.GetAsync(e => e.IdMunicipio == IdMunicipio);
            var Municipio = query.FirstOrDefault();
            return Municipio;
        }

        public async Task<IEnumerable<Municipios>> ObtenerMunicipios(MunicipiosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdMunicipio != null && filters.IdMunicipio != 0)
            {
                Expression<Func<Municipios, bool>> query = (e => e.IdMunicipio == filters.IdMunicipio);
                expressions.Add(query);
            }
            if (filters.IdProvincia != null && filters.IdProvincia != 0)
            {
                Expression<Func<Municipios, bool>> query = (e => e.IdProvincia == filters.IdProvincia);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Municipios, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }
            if(filters.provincias != null && filters.provincias.Count() > 0)
            {
                Expression<Func<Municipios, bool>> query = (e => filters.provincias.Contains(e.IdProvincia));
                expressions.Add(query);
            }

            var data = await _unitOfWork.MunicipiosRepository.AddInclude("").GetAsync(expressions);
            return data;
        }
    }
}