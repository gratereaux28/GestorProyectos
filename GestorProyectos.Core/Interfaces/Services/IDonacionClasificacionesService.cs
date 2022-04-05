using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDonacionClasificacionesService
    {
        Task<DonacionClasificaciones> ObtenerClasificacion(int IdClasificacion);
        Task<IEnumerable<DonacionClasificaciones>> ObtenerClasificacion(DonacionClasificacionesQueryFilter filters);
        Task<DonacionClasificaciones> AgregarClasificacion(DonacionClasificaciones clasificacion);
        Task<bool> ActualizarClasificacion(DonacionClasificaciones clasificacion);
        Task<bool> EliminarDonacionClasificaciones(int IdClasificacion);
    }
}