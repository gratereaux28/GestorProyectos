using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IBeneficiariosService
    {
        Task<Beneficiarios> ObtenerBeneficiario(int IdBeneficiario);
        Task<IEnumerable<Beneficiarios>> ObtenerBeneficiarios(BeneficiariosQueryFilter filters);
        Task<Beneficiarios> AgregarBeneficiario(Beneficiarios benerificio);
        Task<bool> ActualizarBeneficiario(Beneficiarios benerificio);
        Task<bool> EliminarBeneficiario(int IdBeneficiario);
    }
}