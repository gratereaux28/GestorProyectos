using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface ITareasService
    {
        Task<Tareas> ObtenerTarea(int IdTarea);
        Task<IEnumerable<Tareas>> ObtenerTareas(TareasQueryFilter filters);
        Task<Tareas> AgregarTarea(Tareas tarea);
        Task<bool> ActualizarTarea(Tareas tarea);
        Task<bool> EliminarTarea(int IdTarea);
    }
}