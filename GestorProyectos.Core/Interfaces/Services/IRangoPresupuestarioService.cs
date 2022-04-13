using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IRangoPresupuestarioService
    {
        Task<RangoPresupuestario> ObtenerRango(int IdRango);
        Task<IEnumerable<RangoPresupuestario>> ObtenerRango(RangoPresupuestarioQueryFilter filters);
        Task<RangoPresupuestario> AgregarRango(RangoPresupuestario rango);
        Task<bool> ActualizarRango(RangoPresupuestario rango);
        Task<bool> EliminarRangoPresupuestario(int IdRango);
    }
}