using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Models;

namespace GestorProyectos.Core.Interfaces
{
    public interface IOlvidoClaveRepository : IBaseRepository<Usuarios>
    {
        Task EnviarClave(string Usuario, string Clave);
    }
}
