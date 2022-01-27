using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IUsuariosService
    {
        Task<Usuarios> ObtenerUsuario(int IdUsuario);
        Task<Usuarios> ObtenerUsuario(string usuario);
        Task<IEnumerable<Usuarios>> ObtenerUsuarios(UsuariosQueryFilter filters);
        Task<Usuarios> AgregarUsuario(Usuarios usuario);
        Task<bool> ActualizarUsuario(Usuarios usuario);
        Task<bool> EliminarUsuario(int IdUsuario);
    }
}