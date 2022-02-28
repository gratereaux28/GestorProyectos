using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using Microsoft.AspNetCore.Http;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IDocumentosProyectosService
    {
        Task<DocumentosProyectos> ObtenerDocumento(int IdDocumento);
        Task<IEnumerable<DocumentosProyectos>> ObtenerDocumentos(DocumentosProyectosQueryFilter filters);
        Task<DocumentosProyectos> AgregarDocumento(DocumentosProyectos documento);
        Task<bool> ActualizarDocumento(DocumentosProyectos documento);
        Task GuardarDocumentos(IFormFile File, string CodigoProyecto);
        Task<bool> EliminarDocumento(int IdDocumento);
    }
}