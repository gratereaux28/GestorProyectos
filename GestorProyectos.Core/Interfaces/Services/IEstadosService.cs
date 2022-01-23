using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IEstadosService
    {
        Task<Estados> ObtenerEstado(int IdEstado);
        Task<PagedList<Estados>> ObtenerEstados(EstadosQueryFilter filters);
        Task<Estados> AgregarEstado(Estados estado);
        Task<bool> ActualizarEstado(Estados estado);
        Task<bool> EliminarEstado(int IdEstado);
    }
}