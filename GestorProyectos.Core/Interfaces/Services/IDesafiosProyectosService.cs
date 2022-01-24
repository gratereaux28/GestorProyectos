using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDesafiosProyectosService
    {
        Task<DesafiosProyectos> ObtenerDesafio(int IdDesafioProyecto);
        Task<IEnumerable<DesafiosProyectos>> ObtenerDesafiosProyectos(DesafiosProyectosQueryFilter filters);
        Task<DesafiosProyectos> AgregarDesafio(DesafiosProyectos desafio);
        Task<bool> ActualizarDesafio(DesafiosProyectos desafio);
        Task<bool> EliminarDesafio(int IdDesafioProyecto);
    }
}