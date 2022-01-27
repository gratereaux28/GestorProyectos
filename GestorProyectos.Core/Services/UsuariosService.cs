using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuariosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuarios> ObtenerUsuario(int IdUsuario)
        {
            var query = await _unitOfWork.UsuariosRepository.GetAsync(e => e.IdUsuario == IdUsuario);
            var Usuario = query.FirstOrDefault();
            return Usuario;
        }

        public async Task<Usuarios> ObtenerUsuario(string usuario)
        {
            var query = await _unitOfWork.UsuariosRepository.GetAsync(e => e.Usuario == usuario);
            var Usuario = query.FirstOrDefault();
            return Usuario;
        }

        public async Task<IEnumerable<Usuarios>> ObtenerUsuarios(UsuariosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdUsuario != null && filters.IdUsuario != 0)
            {
                Expression<Func<Usuarios, bool>> query = (e => e.IdUsuario == filters.IdUsuario);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Usuario))
            {
                Expression<Func<Usuarios, bool>> query = (e => e.Usuario.ToLower().Contains(filters.Usuario.ToLower()));
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Usuarios, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Apellido))
            {
                Expression<Func<Usuarios, bool>> query = (e => e.Apellido.ToLower().Contains(filters.Apellido.ToLower()));
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Correo))
            {
                Expression<Func<Usuarios, bool>> query = (e => e.Correo.ToLower().Contains(filters.Correo.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.UsuariosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Usuarios> AgregarUsuario(Usuarios usuario)
        {
            usuario.IdUsuario = 0;
            return await _unitOfWork.UsuariosRepository.AddAsync(usuario);
        }

        public async Task<bool> ActualizarUsuario(Usuarios usuario)
        {
            var Usuario = await ObtenerUsuario(usuario.IdUsuario);
            if (Usuario != null)
            {
                usuario.CopyTo(Usuario);
                _unitOfWork.UsuariosRepository.UpdateNoSave(Usuario);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarUsuario(int IdUsuario)
        {
            var Usuario = await ObtenerUsuario(IdUsuario);
            if (Usuario != null)
            {
                _unitOfWork.UsuariosRepository.DeleteNoSave(Usuario);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}