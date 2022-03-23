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
    public class TipoBeneficiarioService : ITipoBeneficiarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public TipoBeneficiarioService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<TipoBeneficiario> ObtenerTipo(int IdTipo)
        {
            var query = await _unitOfWork.TipoBeneficiarioRepository.GetAsync(e => e.IdTipo == IdTipo);
            var TipoBeneficiario = query.FirstOrDefault();
            return TipoBeneficiario;
        }

        public async Task<IEnumerable<TipoBeneficiario>> ObtenerTipo(TipoBeneficiarioQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdTipo != null && filters.IdTipo != 0)
            {
                Expression<Func<TipoBeneficiario, bool>> query = (e => e.IdTipo == filters.IdTipo);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<TipoBeneficiario, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.TipoBeneficiarioRepository.GetAsync(expressions);
            return data;
        }

        public async Task<TipoBeneficiario> AgregarTipo(TipoBeneficiario Tipo)
        {
            Tipo.IdTipo = 0;
            return await _unitOfWork.TipoBeneficiarioRepository.AddAsync(Tipo);
        }

        public async Task<bool> ActualizarTipo(TipoBeneficiario tipo)
        {
            var Tipo = await ObtenerTipo(tipo.IdTipo);
            if (Tipo != null)
            {
                tipo.CopyTo(Tipo);
                _unitOfWork.TipoBeneficiarioRepository.UpdateNoSave(Tipo);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarTipoBeneficiario(int IdTipo)
        {
            var aliado = await ObtenerTipo(IdTipo);
            if (aliado != null)
            {
                _unitOfWork.TipoBeneficiarioRepository.DeleteNoSave(aliado);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}