using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IEjecucionesService
    {
        Task<Ejecuciones> ObtenerEjecucion(int IdEjecucion);
        Task<IEnumerable<Ejecuciones>> ObtenerEjecuciones(EjecucionesQueryFilter filters);
        Task<Ejecuciones> AgregarEjecucion(Ejecuciones ejecucion);
        Task<bool> ActualizarEjecucion(Ejecuciones ejecucion);
        Task<bool> EliminarEjecucion(int IdEjecucion);
    }
}