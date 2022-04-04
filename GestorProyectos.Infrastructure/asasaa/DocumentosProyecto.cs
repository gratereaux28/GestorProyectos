using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class DocumentosProyecto
    {
        public int IdDocumento { get; set; }
        public int IdProyecto { get; set; }
        public int? IdTarea { get; set; }
        public byte[] Contenido { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public int? Size { get; set; }
        public string Ext { get; set; } = null!;
        public string? Url { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
        public virtual Tarea? IdTareaNavigation { get; set; }
    }
}
