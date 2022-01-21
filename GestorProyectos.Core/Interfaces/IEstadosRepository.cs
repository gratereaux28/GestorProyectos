using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Models;

namespace GestorProyectos.Core.Interfaces
{
    public interface IEstadosRepository : IBaseRepository<Estados>
    {
        Task<Estados> AgregarEstado(Estados estado);
        Task<bool> ActualizarEstado(Estados estado);
        Task<bool> EliminarEstado(int IdEstado);
    }
}
