using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class EstadosService : IEstadosService
    {

        private readonly IUnitOfWork _unitOfWork;

        public EstadosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Estados> ObtenerEstado(int IdEstado)
        {
            var query = await _unitOfWork.EstadosRepository.GetAsync(e => e.IdEstado == IdEstado);
            var Estado = query.FirstOrDefault();
            return Estado;
        }

        public async Task<PagedList<Estados>> ObtenerEstados(EstadosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdEstado != null)
            {
                Expression<Func<Estados, bool>> query = (e => e.IdEstado == filters.IdEstado);
                expressions.Add(query);
            }
            if (filters.Nombre != null)
            {
                Expression<Func<Estados, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }
            if (filters.IdTipo != null)
            {
                Expression<Func<Estados, bool>> query = (e => e.IdTipo == filters.IdTipo);
                expressions.Add(query);
            }

            var data = await _unitOfWork.EstadosRepository.GetAsync(expressions);

            var pagedEstados = PagedList<Estados>.Create(data, filters.pageNumber, filters.pageSize);
            return pagedEstados;
        }

        public async Task<Estados> AgregarEstado(Estados estado)
        {
            return await _unitOfWork.EstadosRepository.AddAsync(estado);
        }

        public async Task<bool> ActualizarEstado(Estados estado)
        {
            var Estado = await ObtenerEstado(estado.IdEstado);
            if (Estado != null) estado.CopyTo(Estado);
            _unitOfWork.EstadosRepository.UpdateNoSave(Estado);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarEstado(int IdEstado)
        {
            var Estado = await ObtenerEstado(IdEstado);
            _unitOfWork.EstadosRepository.DeleteNoSave(Estado);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
