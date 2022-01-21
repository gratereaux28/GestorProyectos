using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Extensions.sys;

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
