using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetEstadosPaginationUri(EstadosQueryFilter filter, string actionUrl);
    }
}