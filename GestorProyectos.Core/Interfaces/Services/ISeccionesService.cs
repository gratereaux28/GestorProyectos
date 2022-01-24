using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface ISeccionesService
    {
        Task<Secciones> ObtenerSeccion(int IdSeccion);
        Task<IEnumerable<Secciones>> ObtenerSecciones(SeccionesQueryFilter filters);
    }
}