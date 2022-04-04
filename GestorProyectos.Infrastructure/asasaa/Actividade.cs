using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Actividade
    {
        public Actividade()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int IdActividad { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdProyecto { get; set; }
        public int Orden { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
