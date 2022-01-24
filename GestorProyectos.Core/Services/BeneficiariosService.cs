using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class BeneficiariosService : IBeneficiariosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeneficiariosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Beneficiarios> ObtenerBeneficiario(int IdBeneficiario)
        {
            var query = await _unitOfWork.BeneficiariosRepository.GetAsync(e => e.IdBeneficiario == IdBeneficiario);
            var Beneficiario = query.FirstOrDefault();
            return Beneficiario;
        }

        public async Task<IEnumerable<Beneficiarios>> ObtenerBeneficiarios(BeneficiariosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdBeneficiario != null && filters.IdBeneficiario != 0)
            {
                Expression<Func<Beneficiarios, bool>> query = (e => e.IdBeneficiario == filters.IdBeneficiario);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Beneficiarios, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.BeneficiariosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Beneficiarios> AgregarBeneficiario(Beneficiarios benerificario)
        {
            benerificario.IdBeneficiario = 0;
            return await _unitOfWork.BeneficiariosRepository.AddAsync(benerificario);
        }

        public async Task<bool> ActualizarBeneficiario(Beneficiarios benerificario)
        {
            var Beneficiario = await ObtenerBeneficiario(benerificario.IdBeneficiario);
            if (Beneficiario != null)
            {
                benerificario.CopyTo(Beneficiario);
                _unitOfWork.BeneficiariosRepository.UpdateNoSave(Beneficiario);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return true;
        }

        public async Task<bool> EliminarBeneficiario(int IdBeneficiario)
        {
            var Beneficiario = await ObtenerBeneficiario(IdBeneficiario);
            if (Beneficiario != null)
            {
                _unitOfWork.BeneficiariosRepository.DeleteNoSave(Beneficiario);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return true;
        }
    }
}