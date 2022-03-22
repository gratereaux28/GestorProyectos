using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class DivisionTrabajoProyectos
    {
        public int IdDivision { get; set; }
        public int IdParticipante { get; set; }
        public int IdNivelAcceso { get; set; }
        public int CantidadAsignaciones { get; set; }

        public virtual NivelAcceso NivelAcceso { get; set; } = null!;
    }
}
