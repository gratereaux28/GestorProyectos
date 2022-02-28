using Microsoft.AspNetCore.Http;

namespace GestorProyectos.Api.Models
{
    public class DocumentosProyectoFile
    {
        public IFormFile File { get; set; }
        public string CodigoProyecto { get; set; }
        public int size { get; set; }
    }
}
