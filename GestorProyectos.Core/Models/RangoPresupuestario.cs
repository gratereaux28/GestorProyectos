using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class RangoPresupuestario
    {
        public RangoPresupuestario()
        {
            Proyectos = new HashSet<Proyectos>();
        }

        public int IdRango { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Proyectos> Proyectos { get; set; }
    }
}
