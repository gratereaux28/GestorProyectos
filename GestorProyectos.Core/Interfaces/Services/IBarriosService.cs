using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IBarriosService
    {
        Task<PagedList<Barrios>> ObtenerBarrios(BarriosQueryFilter filters);
    }
}