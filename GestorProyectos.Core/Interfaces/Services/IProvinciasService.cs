using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IProvinciasService
    {
        Task<Provincias> ObtenerProvincia(int IdProvincia);
        Task<IEnumerable<Provincias>> ObtenerProvincias(ProvinciasQueryFilter filters);
    }
}