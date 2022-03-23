using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Actividades
    {
        public Actividades()
        {
            Tareas = new HashSet<Tareas>();
        }

        public int IdActividad { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdProyecto { get; set; }
        public int Orden { get; set; }

        public virtual Proyectos Proyecto { get; set; } = null!;
        public virtual ICollection<Tareas> Tareas { get; set; } = null!;
    }
}
