using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Models;

namespace GestorProyectos.Core.Interfaces
{
    public interface IEstadosRepository : IBaseRepository<Estados>
    {
        Task<Estados> AgregarEstados(Estados estado);
    }
}
