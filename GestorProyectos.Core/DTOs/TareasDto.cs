using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class TareasDto
    {
        public int IdTarea { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdEstado { get; set; }

        public virtual EstadosDto Estado { get; set; } = null!;
        public virtual ProyectosDto Proyecto { get; set; } = null!;
        public virtual ICollection<DocumentosProyectosDto> DocumentosProyectos { get; set; }
    }
}