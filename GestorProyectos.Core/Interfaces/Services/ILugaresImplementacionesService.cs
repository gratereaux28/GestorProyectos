using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface ILugaresImplementacionesService
    {
        Task<LugaresImplementaciones> ObtenerImplementacion(int IdImplementacion);
        Task<IEnumerable<LugaresImplementaciones>> ObtenerLugaresImplementaciones(LugaresImplementacionesQueryFilter filters);
        Task<LugaresImplementaciones> AgregarImplementacion(LugaresImplementaciones implementacion);
        Task<bool> ActualizarImplementacion(LugaresImplementaciones implementacion);
        Task<bool> EliminarImplementacion(int IdImplementacion);
    }
}