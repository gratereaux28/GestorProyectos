using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface ITiposBeneficiarioProyectoService
    {
        Task<TiposBeneficiarioProyecto> ObtenerTipo(int IdTipoBeneficiarioProyecto);
        Task<IEnumerable<TiposBeneficiarioProyecto>> ObtenerTipo(TiposBeneficiarioProyectoQueryFilter filters);
        Task<TiposBeneficiarioProyecto> AgregarTipo(TiposBeneficiarioProyecto Tipo);
        Task<bool> ActualizarTipo(TiposBeneficiarioProyecto tipo);
        Task<bool> EliminarTiposBeneficiarioProyecto(int IdTipoBeneficiarioProyecto);
    }
}