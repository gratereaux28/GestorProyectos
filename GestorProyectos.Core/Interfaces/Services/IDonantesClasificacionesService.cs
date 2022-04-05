using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDonantesClasificacionesService
    {
        Task<DonantesClasificaciones> ObtenerClasificacion(int IdClasificacion);
        Task<IEnumerable<DonantesClasificaciones>> ObtenerClasificacion(DonantesClasificacionesQueryFilter filters);
        Task<DonantesClasificaciones> AgregarClasificacion(DonantesClasificaciones clasificacion);
        Task<bool> ActualizarClasificacion(DonantesClasificaciones clasificacion);
        Task<bool> EliminarDonantesClasificaciones(int IdClasificacion);
    }
}