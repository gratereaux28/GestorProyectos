using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IProyectosService
    {
        Task<Proyectos> ObtenerProyecto(int IdProyecto);
        Task<IEnumerable<Proyectos>> ObtenerProyectos(ProyectosQueryFilter filters);
        Task<Proyectos> AgregarProyecto(Proyectos proyecto, IEnumerable<DocumentosProyectosDto> documentos);
        Task<bool> ActualizarProyecto(Proyectos proyecto, IEnumerable<DocumentosProyectosDto> documentos);
        Task<bool> EliminarProyecto(int IdProyecto);
    }
}