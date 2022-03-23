using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IRangoBeneficiariosService
    {
        Task<RangoBeneficiarios> ObtenerRango(int IdRango);
        Task<IEnumerable<RangoBeneficiarios>> ObtenerRango(RangoBeneficiariosQueryFilter filters);
        Task<RangoBeneficiarios> AgregarRango(RangoBeneficiarios Rango);
        Task<bool> ActualizarRango(RangoBeneficiarios rango);
        Task<bool> EliminarRangoBeneficiarios(int IdRango);
    }
}