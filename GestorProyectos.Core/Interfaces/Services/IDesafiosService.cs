using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDesafiosService
    {
        Task<Desafios> ObtenerDesafio(int IdDesafio);
        Task<IEnumerable<Desafios>> ObtenerDesafios(DesafiosQueryFilter filters);
        Task<Desafios> AgregarDesafio(Desafios desafio);
        Task<bool> ActualizarDesafio(Desafios desafio);
        Task<bool> EliminarDesafio(int IdDesafio);
    }
}