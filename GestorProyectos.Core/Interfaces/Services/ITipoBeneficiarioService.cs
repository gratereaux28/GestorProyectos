using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface ITipoBeneficiarioService
    {
        Task<TipoBeneficiario> ObtenerTipo(int IdTipo);
        Task<IEnumerable<TipoBeneficiario>> ObtenerTipo(TipoBeneficiarioQueryFilter filters);
        Task<TipoBeneficiario> AgregarTipo(TipoBeneficiario Tipo);
        Task<bool> ActualizarTipo(TipoBeneficiario tipo);
        Task<bool> EliminarTipoBeneficiario(int IdTipo);
    }
}