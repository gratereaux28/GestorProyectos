using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Infrastructure.Extensions;
using GestorProyectos.Infrastructure.Interfaces;

namespace GestorProyectos.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPaginationUri(object filter, int PageSize, int NextPage, string actionUrl)
        {
            string queryString = filter.GetQueryString() + $"&PageNumber={NextPage}";
            //queryString = queryString.Replace($"PageNumber={CurrentPage}", $"PageNumber={NextPage}");
            string baseUrl = $"{_baseUri}{actionUrl}?{queryString}";
            //string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

        public Uri GetEstadosPaginationUri(EstadosQueryFilter filter, string actionUrl)
        {
            string queryString = filter.GetQueryString();
            string baseUrl = $"{_baseUri}{actionUrl}?{queryString}";
            return new Uri(baseUrl);
        }

        public Uri GetBarriosPaginationUri(BarriosQueryFilter filter, string actionUrl)
        {
            string queryString = filter.GetQueryString();
            string baseUrl = $"{_baseUri}{actionUrl}?{queryString}";
            return new Uri(baseUrl);
        }
    }
}