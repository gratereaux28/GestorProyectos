using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPaginationUri(object filter, int PageSize, int CurrentPage, string actionUrl);
    }
}