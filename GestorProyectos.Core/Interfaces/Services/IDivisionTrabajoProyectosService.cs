using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDivisionTrabajoProyectosService
    {
        Task<DivisionTrabajoProyectos> ObtenerDivision(int IdDivision);
        Task<IEnumerable<DivisionTrabajoProyectos>> ObtenerDivisionTrabajoProyectos(DivisionTrabajoProyectosQueryFilter filters);
        Task<DivisionTrabajoProyectos> AgregarDivision(DivisionTrabajoProyectos Division);
        Task<bool> ActualizarDivision(DivisionTrabajoProyectos division);
        Task<bool> EliminarDivision(int IdDivision);
    }
}