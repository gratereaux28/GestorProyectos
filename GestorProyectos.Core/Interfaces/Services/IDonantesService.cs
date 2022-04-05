using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDonantesService
    {
        Task<Donantes> ObtenerDonante(int IdDonante);
        Task<IEnumerable<Donantes>> ObtenerDonante(DonantesQueryFilter filters);
        Task<Donantes> AgregarDonante(Donantes donante);
        Task<bool> ActualizarDonante(Donantes donante);
        Task<bool> EliminarDonantes(int IdDonante);
    }
}