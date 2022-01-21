using GestorProyectos.Core.Models;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IEstadosService
    {
        Task<Estados> ObtenerEstado(int IdEstado);
        Task<Estados> AgregarEstado(Estados estado);
        Task<bool> ActualizarEstado(Estados estado);
        Task<bool> EliminarEstado(int IdEstado);
    }
}