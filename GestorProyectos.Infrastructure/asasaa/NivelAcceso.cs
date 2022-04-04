using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class NivelAcceso
    {
        public NivelAcceso()
        {
            DivisionTrabajoProyectos = new HashSet<DivisionTrabajoProyecto>();
        }

        public int IdNivelAcceso { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<DivisionTrabajoProyecto> DivisionTrabajoProyectos { get; set; }
    }
}
