using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class OlvidoClaveService : IOlvidoClaveService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OlvidoClaveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task EnviarClave(string Usuario, string Clave)
        {
            await _unitOfWork.OlvidoClaveRepository.EnviarClave(Usuario, Clave);
        }
    }
}