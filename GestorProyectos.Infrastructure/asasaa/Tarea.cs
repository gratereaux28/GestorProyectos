using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Tarea
    {
        public Tarea()
        {
            DocumentosProyectos = new HashSet<DocumentosProyecto>();
        }

        public int IdTarea { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdActividad { get; set; }
        public int? IdResponsable { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Actividade IdActividadNavigation { get; set; } = null!;
        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual Usuario? IdResponsableNavigation { get; set; }
        public virtual ICollection<DocumentosProyecto> DocumentosProyectos { get; set; }
    }
}
