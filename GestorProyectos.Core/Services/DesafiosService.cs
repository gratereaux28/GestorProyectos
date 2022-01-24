using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class DesafiosService : IDesafiosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DesafiosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Desafios> ObtenerDesafio(int IdDesafio)
        {
            var query = await _unitOfWork.DesafiosRepository.GetAsync(e => e.IdDesafio == IdDesafio);
            var Desafio = query.FirstOrDefault();
            return Desafio;
        }

        public async Task<IEnumerable<Desafios>> ObtenerDesafios(DesafiosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdDesafio != null && filters.IdDesafio != 0)
            {
                Expression<Func<Desafios, bool>> query = (e => e.IdDesafio == filters.IdDesafio);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Desafios, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.DesafiosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Desafios> AgregarDesafio(Desafios desafio)
        {
            desafio.IdDesafio = 0;
            return await _unitOfWork.DesafiosRepository.AddAsync(desafio);
        }

        public async Task<bool> ActualizarDesafio(Desafios desafio)
        {
            var Desafio = await ObtenerDesafio(desafio.IdDesafio);
            if (Desafio != null)
            {
                desafio.CopyTo(Desafio);
                _unitOfWork.DesafiosRepository.UpdateNoSave(Desafio);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarDesafio(int IdDesafio)
        {
            var Desafio = await ObtenerDesafio(IdDesafio);
            if (Desafio != null)
            {
                _unitOfWork.DesafiosRepository.DeleteNoSave(Desafio);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}