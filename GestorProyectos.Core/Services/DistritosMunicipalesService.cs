using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class DistritosMunicipalesService : IDistritosMunicipalesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistritosMunicipalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DistritosMunicipales> ObtenerDistritoMunicipal(int IdDistrito)
        {
            var query = await _unitOfWork.DistritosMunicipalesRepository.GetAsync(e => e.IdDistrito == IdDistrito);
            var Distrito = query.FirstOrDefault();
            return Distrito;
        }

        public async Task<IEnumerable<DistritosMunicipales>> ObtenerDistritosMunicipales(DistritosMunicipalesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdDistrito != null && filters.IdDistrito != 0)
            {
                Expression<Func<DistritosMunicipales, bool>> query = (e => e.IdDistrito == filters.IdDistrito);
                expressions.Add(query);
            }
            if (filters.IdMunicipio != null && filters.IdMunicipio != 0)
            {
                Expression<Func<DistritosMunicipales, bool>> query = (e => e.IdMunicipio == filters.IdMunicipio);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<DistritosMunicipales, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.DistritosMunicipalesRepository.GetAsync(expressions);
            return data;
        }

        public async Task<DistritosMunicipales> AgregarDistritoMunicipal(DistritosMunicipales distrito)
        {
            distrito.IdDistrito = 0;
            return await _unitOfWork.DistritosMunicipalesRepository.AddAsync(distrito);
        }

        public async Task<bool> ActualizarDistritoMunicipal(DistritosMunicipales distrito)
        {
            var Distrito = await ObtenerDistritoMunicipal(distrito.IdDistrito);
            if (Distrito != null)
            {
                distrito.CopyTo(Distrito);
                _unitOfWork.DistritosMunicipalesRepository.UpdateNoSave(Distrito);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarDistritoMunicipal(int IdDistrito)
        {
            var Distrito = await ObtenerDistritoMunicipal(IdDistrito);
            if (Distrito != null)
            {
                _unitOfWork.DistritosMunicipalesRepository.DeleteNoSave(Distrito);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}