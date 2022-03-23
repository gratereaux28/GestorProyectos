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
    public class NivelAccesoService : INivelAccesoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public NivelAccesoService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<NivelAcceso> ObtenerNivel(int IdNivelAcceso)
        {
            var query = await _unitOfWork.NivelAccesoRepository.GetAsync(e => e.IdNivelAcceso == IdNivelAcceso);
            var NivelAcceso = query.FirstOrDefault();
            return NivelAcceso;
        }

        public async Task<IEnumerable<NivelAcceso>> ObtenerNivel(NivelAccesoQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdNivelAcceso != null && filters.IdNivelAcceso != 0)
            {
                Expression<Func<NivelAcceso, bool>> query = (e => e.IdNivelAcceso == filters.IdNivelAcceso);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<NivelAcceso, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.NivelAccesoRepository.GetAsync(expressions);
            return data;
        }

        public async Task<NivelAcceso> AgregarNivel(NivelAcceso Nivel)
        {
            Nivel.IdNivelAcceso = 0;
            return await _unitOfWork.NivelAccesoRepository.AddAsync(Nivel);
        }

        public async Task<bool> ActualizarNivel(NivelAcceso nivel)
        {
            var Nivel = await ObtenerNivel(nivel.IdNivelAcceso);
            if (Nivel != null)
            {
                nivel.CopyTo(Nivel);
                _unitOfWork.NivelAccesoRepository.UpdateNoSave(Nivel);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarNivelAcceso(int IdNivelAcceso)
        {
            var Nivel = await ObtenerNivel(IdNivelAcceso);
            if (Nivel != null)
            {
                _unitOfWork.NivelAccesoRepository.DeleteNoSave(Nivel);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}