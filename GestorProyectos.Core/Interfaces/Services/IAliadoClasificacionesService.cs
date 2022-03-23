using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IAliadoClasificacionesService
    {
        Task<AliadoClasificaciones> ObtenerClasificacion(int IdClasificacion);
        Task<IEnumerable<AliadoClasificaciones>> ObtenerClasificacion(AliadoClasificacionesQueryFilter filters);
        Task<AliadoClasificaciones> AgregarClasificacion(AliadoClasificaciones clasificacion);
        Task<bool> ActualizarClasificacion(AliadoClasificaciones clasificacion);
        Task<bool> EliminarAliadoClasificaciones(int IdClasificacion);
    }
}