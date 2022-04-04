using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class DivisionTrabajoProyecto
    {
        public int IdDivision { get; set; }
        public int IdParticipante { get; set; }
        public int IdNivelAcceso { get; set; }
        public int CantidadAsignaciones { get; set; }

        public virtual NivelAcceso IdNivelAccesoNavigation { get; set; } = null!;
    }
}
