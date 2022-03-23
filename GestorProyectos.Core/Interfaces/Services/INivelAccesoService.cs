using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface INivelAccesoService
    {
        Task<NivelAcceso> ObtenerNivel(int IdNivelAcceso);
        Task<IEnumerable<NivelAcceso>> ObtenerNivel(NivelAccesoQueryFilter filters);
        Task<NivelAcceso> AgregarNivel(NivelAcceso Nivel);
        Task<bool> ActualizarNivel(NivelAcceso nivel);
        Task<bool> EliminarNivelAcceso(int IdNivelAcceso);
    }
}