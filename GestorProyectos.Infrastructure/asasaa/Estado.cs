using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Estado
    {
        public Estado()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int IdEstado { get; set; }
        public string IdTipo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int? Orden { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
