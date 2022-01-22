using GestorProyectos.Core.QueryFilter;
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

        public Uri GetEstadosPaginationUri(EstadosQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}