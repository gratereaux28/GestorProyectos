using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDistritosMunicipalesService
    {
        Task<DistritosMunicipales> ObtenerDistritoMunicipal(int IdDistrito);
        Task<IEnumerable<DistritosMunicipales>> ObtenerDistritosMunicipales(DistritosMunicipalesQueryFilter filters);
        Task<DistritosMunicipales> AgregarDistritoMunicipal(DistritosMunicipales distrito);
        Task<bool> ActualizarDistritoMunicipal(DistritosMunicipales distrito);
        Task<bool> EliminarDistritoMunicipal(int IdDistrito);
    }
}