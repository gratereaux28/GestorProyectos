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
    public class Aliadoervice : IAliadoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public Aliadoervice(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }


        public async Task<Aliado> ObtenerAliado(int IdAliado)
        {
            var query = await _unitOfWork.AliadoRepository.GetAsync(e => e.IdAliado == IdAliado);
            var Aliado = query.FirstOrDefault();
            return Aliado;
        }

        public async Task<IEnumerable<Aliado>> ObtenerAliado(AliadoQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdAliado != null && filters.IdAliado != 0)
            {
                Expression<Func<Aliado, bool>> query = (e => e.IdAliado == filters.IdAliado);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Aliado, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.AliadoRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Aliado> AgregarAliado(Aliado Aliado)
        {
            Aliado.IdAliado = 0;
            return await _unitOfWork.AliadoRepository.AddAsync(Aliado);
        }

        public async Task<bool> ActualizarAliado(Aliado aliado)
        {
            var Aliado = await ObtenerAliado(aliado.IdAliado);
            if (Aliado != null)
            {
                aliado.CopyTo(Aliado);
                _unitOfWork.AliadoRepository.UpdateNoSave(Aliado);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarAliado(int IdAliado)
        {
            var Aliado = await ObtenerAliado(IdAliado);
            if (Aliado != null)
            {
                _unitOfWork.AliadoRepository.DeleteNoSave(Aliado);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}