using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class DocumentosProyectosDto
    {
        public int IdDocumento { get; set; }
        public int IdProyecto { get; set; }
        public int? IdTarea { get; set; }
        public byte[] Contenido { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string Ext { get; set; } = null!;
        public string? Url { get; set; }

        public virtual ProyectosDto Proyecto { get; set; } = null!;
        public virtual TareasDto Tarea { get; set; }
    }
}