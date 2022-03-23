using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class DivisionTrabajoProyectosDto
    {
        public int IdDivision { get; set; }
        public int IdParticipante { get; set; }
        public int IdNivelAcceso { get; set; }
        public int CantidadAsignaciones { get; set; }
    }
}
