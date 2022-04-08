using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IOlvidoClaveService
    {
        Task EnviarClave(string Usuario, string Clave);
    }
}