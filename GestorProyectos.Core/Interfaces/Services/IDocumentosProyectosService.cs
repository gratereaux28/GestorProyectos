using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Services
{
    public interface IDocumentosProyectosService
    {
        Task<DocumentosProyectos> ObtenerDocumento(int IdDocumento);
        Task<IEnumerable<DocumentosProyectos>> ObtenerDocumentos(DocumentosProyectosQueryFilter filters);
        Task<DocumentosProyectos> AgregarDocumento(DocumentosProyectos estado);
        Task<bool> ActualizarDocumento(DocumentosProyectos documento);
        Task<bool> EliminarDocumento(int IdDocumento);
    }
}