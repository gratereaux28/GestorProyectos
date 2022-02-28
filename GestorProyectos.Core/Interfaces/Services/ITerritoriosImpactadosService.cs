using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface ITerritoriosImpactadosService
    {
        Task<TerritoriosImpactados> ObtenerImpacto(int IdImpacto);
        Task<IEnumerable<TerritoriosImpactados>> ObtenerTerritoriosImpactados(TerritoriosImpactadosQueryFilter filters);
        Task<IEnumerable<TerritoriosImpactados>> ObtenerListaTerritoriosImpactados(List<int> ids);
        Task<TerritoriosImpactados> AgregarImpacto(TerritoriosImpactados impacto);
        Task<bool> ActualizarImpacto(TerritoriosImpactados impacto);
        Task<bool> EliminarImpacto(int IdImpacto);
    }
}