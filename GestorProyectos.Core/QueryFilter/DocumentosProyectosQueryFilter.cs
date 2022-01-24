using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class DocumentosProyectosQueryFilter : BaseQueryFilter
    {
        public int? IdDocumento { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdTarea { get; set; }
        public byte[]? Contenido { get; set; }
        public DateTime? Fecha { get; set; }
        public string? NombreArchivo { get; set; }
        public string? Ext { get; set; }
        public string? Url { get; set; }
    }
}