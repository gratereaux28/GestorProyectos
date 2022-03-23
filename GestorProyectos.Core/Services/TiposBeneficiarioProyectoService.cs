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
    public class TiposBeneficiarioProyectoService : ITiposBeneficiarioProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public TiposBeneficiarioProyectoService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<TiposBeneficiarioProyecto> ObtenerTipo(int IdTipoBeneficiarioProyecto)
        {
            var query = await _unitOfWork.TiposBeneficiarioProyectoRepository.GetAsync(e => e.IdTipoBeneficiarioProyecto == IdTipoBeneficiarioProyecto);
            var TiposBeneficiarioProyecto = query.FirstOrDefault();
            return TiposBeneficiarioProyecto;
        }

        public async Task<IEnumerable<TiposBeneficiarioProyecto>> ObtenerTipo(TiposBeneficiarioProyectoQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdTipoBeneficiarioProyecto != null && filters.IdTipoBeneficiarioProyecto != 0)
            {
                Expression<Func<TiposBeneficiarioProyecto, bool>> query = (e => e.IdTipoBeneficiarioProyecto == filters.IdTipoBeneficiarioProyecto);
                expressions.Add(query);
            }

            var data = await _unitOfWork.TiposBeneficiarioProyectoRepository.GetAsync(expressions);
            return data;
        }

        public async Task<TiposBeneficiarioProyecto> AgregarTipo(TiposBeneficiarioProyecto Tipo)
        {
            Tipo.IdTipoBeneficiarioProyecto = 0;
            return await _unitOfWork.TiposBeneficiarioProyectoRepository.AddAsync(Tipo);
        }

        public async Task<bool> ActualizarTipo(TiposBeneficiarioProyecto tipo)
        {
            var Tipo = await ObtenerTipo(tipo.IdTipoBeneficiarioProyecto);
            if (Tipo != null)
            {
                tipo.CopyTo(Tipo);
                _unitOfWork.TiposBeneficiarioProyectoRepository.UpdateNoSave(Tipo);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarTiposBeneficiarioProyecto(int IdTipoBeneficiarioProyecto)
        {
            var Tipo = await ObtenerTipo(IdTipoBeneficiarioProyecto);
            if (Tipo != null)
            {
                _unitOfWork.TiposBeneficiarioProyectoRepository.DeleteNoSave(Tipo);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}