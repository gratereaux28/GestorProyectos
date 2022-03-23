using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IActividadesService
    {
        Task<Actividades> ObtenerActividad(int IdActividad);
        Task<IEnumerable<Actividades>> ObtenerActividad(ActividadesQueryFilter filters);
        Task<Actividades> AgregarActividad(Actividades Actividad);
        Task<bool> ActualizarActividad(Actividades actividad);
        Task<bool> EliminarActividades(int IdActividad);
    }
}