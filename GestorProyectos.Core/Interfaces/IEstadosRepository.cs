using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces
{
    public interface IEstadosRepository : IBaseRepository<Estados>
    {
        Task<Estados> ObtenerEstado(int IdEstado);
        Task<IEnumerable<Estados>> ObtenerEstados(EstadosQueryFilter filters);
        Task<Estados> AgregarEstado(Estados estado);
        Task<bool> ActualizarEstado(Estados estado);
        Task<bool> EliminarEstado(int IdEstado);
    }
}
