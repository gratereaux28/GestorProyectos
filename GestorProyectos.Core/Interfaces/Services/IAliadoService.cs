using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IAliadoService
    {
        Task<Aliado> ObtenerAliado(int IdAliado);
        Task<IEnumerable<Aliado>> ObtenerAliado(AliadoQueryFilter filters);
        Task<Aliado> AgregarAliado(Aliado Aliado);
        Task<bool> ActualizarAliado(Aliado aliado);
        Task<bool> EliminarAliado(int IdAliado);
    }
}