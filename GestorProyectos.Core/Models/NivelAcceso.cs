using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class NivelAcceso
    {
        public NivelAcceso()
        {
            DivisionTrabajoProyectos = new HashSet<DivisionTrabajoProyectos>();
        }

        public int IdNivelAcceso { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<DivisionTrabajoProyectos> DivisionTrabajoProyectos { get; set; }
    }
}
