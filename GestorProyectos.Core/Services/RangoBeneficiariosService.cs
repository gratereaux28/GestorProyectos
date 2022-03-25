using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Exceptions;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class RangoBeneficiariosService : IRangoBeneficiariosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public RangoBeneficiariosService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<RangoBeneficiarios> ObtenerRango(int IdRango)
        {
            var query = await _unitOfWork.RangoBeneficiariosRepository.GetAsync(e => e.IdRango == IdRango);
            var RangoBeneficiarios = query.FirstOrDefault();
            return RangoBeneficiarios;
        }

        public async Task<IEnumerable<RangoBeneficiarios>> ObtenerRango(RangoBeneficiariosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdRango != null && filters.IdRango != 0)
            {
                Expression<Func<RangoBeneficiarios, bool>> query = (e => e.IdRango == filters.IdRango);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<RangoBeneficiarios, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.RangoBeneficiariosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<RangoBeneficiarios> AgregarRango(RangoBeneficiarios Rango)
        {
            Rango.IdRango = 0;
            return await _unitOfWork.RangoBeneficiariosRepository.AddAsync(Rango);
        }

        public async Task<bool> ActualizarRango(RangoBeneficiarios rango)
        {
            var Rango = await ObtenerRango(rango.IdRango);
            if (Rango != null)
            {
                rango.CopyTo(Rango);
                _unitOfWork.RangoBeneficiariosRepository.UpdateNoSave(Rango);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarRangoBeneficiarios(int IdRango)
        {
            var rango = await ObtenerRango(IdRango);
            if (rango != null)
            {
                _unitOfWork.RangoBeneficiariosRepository.DeleteNoSave(rango);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}