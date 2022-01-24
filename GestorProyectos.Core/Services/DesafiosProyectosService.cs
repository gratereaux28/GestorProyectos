using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class DesafiosProyectosService : IDesafiosProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DesafiosProyectosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DesafiosProyectos> ObtenerDesafio(int IdDesafioProyecto)
        {
            var query = await _unitOfWork.DesafiosProyectosRepository.GetAsync(e => e.IdDesafioProyecto == IdDesafioProyecto);
            var Desafio = query.FirstOrDefault();
            return Desafio;
        }

        public async Task<IEnumerable<DesafiosProyectos>> ObtenerDesafiosProyectos(DesafiosProyectosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdDesafio != null && filters.IdDesafio != 0)
            {
                Expression<Func<DesafiosProyectos, bool>> query = (e => e.IdDesafio == filters.IdDesafio);
                expressions.Add(query);
            }
            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<DesafiosProyectos, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
                expressions.Add(query);
            }

            var data = await _unitOfWork.DesafiosProyectosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<DesafiosProyectos> AgregarDesafio(DesafiosProyectos desafio)
        {
            desafio.IdDesafioProyecto = 0;
            return await _unitOfWork.DesafiosProyectosRepository.AddAsync(desafio);
        }

        public async Task<bool> ActualizarDesafio(DesafiosProyectos desafio)
        {
            var Desafio = await ObtenerDesafio(desafio.IdDesafioProyecto);
            if (Desafio != null)
            {
                desafio.CopyTo(Desafio);
                _unitOfWork.DesafiosProyectosRepository.UpdateNoSave(Desafio);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarDesafio(int IdDesafioProyecto)
        {
            var Desafio = await ObtenerDesafio(IdDesafioProyecto);
            if (Desafio != null)
            {
                _unitOfWork.DesafiosProyectosRepository.DeleteNoSave(Desafio);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}