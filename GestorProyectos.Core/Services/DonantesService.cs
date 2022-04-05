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
    public class DonantesService : IDonantesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public DonantesService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        

        public async Task<Donantes> ObtenerDonante(int IdDonante)
        {
            var query = await _unitOfWork.DonantesRepository.GetAsync(e => e.IdDonante == IdDonante);
            var donante = query.FirstOrDefault();
            return donante;
        }

        public async Task<IEnumerable<Donantes>> ObtenerDonante(DonantesQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdDonante != null && filters.IdDonante != 0)
            {
                Expression<Func<Donantes, bool>> query = (e => e.IdDonante == filters.IdDonante);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Donantes, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.DonantesRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Donantes> AgregarDonante(Donantes donante)
        {
            donante.IdDonante = 0;
            return await _unitOfWork.DonantesRepository.AddAsync(donante);
        }

        public async Task<bool> ActualizarDonante(Donantes donante)
        {
            var Donante = await ObtenerDonante(donante.IdDonante);
            if (Donante != null)
            {
                donante.CopyTo(Donante);
                _unitOfWork.DonantesRepository.UpdateNoSave(Donante);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarDonantes(int IdDonante)
        {
            var Donante = await ObtenerDonante(IdDonante);
            if (Donante != null)
            {
                _unitOfWork.DonantesRepository.DeleteNoSave(Donante);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}